using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordMinigame : MonoBehaviour
{
    public Button[] passwordButtons;
    public int correctRoundsRequired = 5;
    public Button button;

    private int correctRounds = 0;
    private int correctIndex;

    private string[] weakPasswords = { "studyhard", "Freedom21", "Luna1234", "hello123", "qwerty", "sunshine" };
    private string[] strongPasswords = { "W1nDy!Sn0w_84dF0x", "Gh0$7P@ssw0rd!", "R3dM00n#Sky98", "S@feH0use_99!" };

    void Start()
    {
        SetupNewRound();
    }

    void SetupNewRound()
    {
        correctIndex = Random.Range(0, passwordButtons.Length);

        for (int i = 0; i < passwordButtons.Length; i++)
        {
            Button btn = passwordButtons[i];
            TextMeshProUGUI tmp = btn.GetComponentInChildren<TextMeshProUGUI>();

            if (i == correctIndex)
            {
                string strong = strongPasswords[Random.Range(0, strongPasswords.Length)];
                tmp.text = strong;

                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => OnCorrectChoice());
            }
            else
            {
                string weak = weakPasswords[Random.Range(0, weakPasswords.Length)];
                tmp.text = weak;

                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => OnWrongChoice());
            }
        }
    }

    void OnCorrectChoice()
    {
        correctRounds++;
        if (correctRounds >= correctRoundsRequired)
        {
            FindObjectOfType<ObjectiveManager>()?.CompleteObjective(1);
            button.interactable = false;
            gameObject.SetActive(false);
        }
        else
        {
            SetupNewRound();
        }
    }

    void OnWrongChoice()
    {
        SetupNewRound();
    }
}