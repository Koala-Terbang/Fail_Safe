using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CodingMinigame : MonoBehaviour
{
    public TMP_InputField inputField;

    [TextArea] public string[] answers;
    public GameObject[] panels;
    public Button button;

    int index = 0;

    void Start()
    {
        for (int i = 0; i < panels.Length; i++)
            panels[i].SetActive(i == 0);

        inputField.lineType = TMP_InputField.LineType.SingleLine;
        inputField.onEndEdit.RemoveAllListeners();
        inputField.onEndEdit.AddListener(OnSubmit);

        ResetField();
    }

    void OnSubmit(string text)
    {
        if (text.Trim() == answers[index].Trim())
        {
            panels[index].SetActive(false);
            index++;

            if (index >= answers.Length)
            {
                inputField.interactable = false;
                button.interactable = false;
                gameObject.SetActive(false);
                FindObjectOfType<ObjectiveManager>()?.CompleteObjective(1);
                FindObjectOfType<Notifications>().PopNotif();
                return;
            }

            panels[index].SetActive(true);
            ResetField();
        }
        else
        {
            FindObjectOfType<TryAgain>().tryAgain();
            ResetField();
        }
    }

    void ResetField()
    {
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
        inputField.caretPosition = 0;
    }
}
