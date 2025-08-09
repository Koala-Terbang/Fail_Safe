using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class PasswordLevel
{
    public string Task;
    public string Dept;
    public string User;
    public string[] options = new string[4];
    public int correctIndex;
}

public class PasswordMinigame : MonoBehaviour
{
    public TMP_Text taskText;
    public TMP_Text deptText;
    public TMP_Text userText;

    public Button[] passwordButtons;

    public Button button;

    public List<PasswordLevel> levels = new List<PasswordLevel>();
    private int currentLevel = 0;

    private float typeSpeed = 0.03f;

    void Start()
    {
        StartCoroutine(ShowIntroThenPasswords());
    }
    IEnumerator ShowIntroThenPasswords()
    {
        taskText.text = "";
        deptText.text = "";
        userText.text = "";

        foreach (var btn in passwordButtons)
        {
            btn.GetComponentInChildren<TMP_Text>().text = "";
            btn.interactable = false;
        }

        PasswordLevel level = levels[currentLevel];

        yield return Typewriter(taskText, level.Task);
        yield return new WaitForSeconds(0.3f);

        yield return Typewriter(deptText, level.Dept);
        yield return new WaitForSeconds(0.3f);

        yield return Typewriter(userText, level.User);
        yield return new WaitForSeconds(0.5f);

        SetupNewRound();
    }

    void SetupNewRound()
    {
        PasswordLevel level = levels[currentLevel];

        for (int i = 0; i < passwordButtons.Length; i++)
        {
            Button btn = passwordButtons[i];
            TMP_Text tmp = btn.GetComponentInChildren<TMP_Text>();

            tmp.text = "";
            btn.interactable = false;

            StartCoroutine(RevealPassword(tmp, level.options[i], btn, i == level.correctIndex));
        }
    }

    IEnumerator RevealPassword(TMP_Text textField, string content, Button btn, bool isCorrect)
    {
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < content.Length; i++)
        {
            textField.text += content[i];
            yield return new WaitForSeconds(typeSpeed);
        }

        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() =>
        {
            if (isCorrect)
            {
                OnCorrectChoice();

            }
            else OnWrongChoice();
        });
        btn.interactable = true;
    }

    void OnCorrectChoice()
    {
        currentLevel++;
        if (currentLevel >= levels.Count)
        {
            FindObjectOfType<ObjectiveManager>()?.CompleteObjective(1);
            button.interactable = false;
            gameObject.SetActive(false);
            FindObjectOfType<Notifications>().PopNotif();
            return;
        }
        StartCoroutine(ShowIntroThenPasswords());
    }

    void OnWrongChoice()
    {
        FindObjectOfType<TryAgain>().tryAgain();
        StartCoroutine(ShowIntroThenPasswords());
    }

    IEnumerator Typewriter(TMP_Text target, string text)
    {
        target.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            target.text += text[i];
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
