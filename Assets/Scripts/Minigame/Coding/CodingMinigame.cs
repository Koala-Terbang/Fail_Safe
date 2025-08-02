using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CodingMinigame : MonoBehaviour
{
    public TMP_Text targetText;
    public TMP_InputField inputField;
    public TMP_Text feedbackText;

    public string[] codeLines;

    private int currentIndex = 0;
    private int correctCount = 0;
    private int totalwords;

    void Start()
    {
        totalwords = codeLines.Length;
        ShowNewLine();
        inputField.onSubmit.AddListener(CheckAnswer);
    }

    void ShowNewLine()
    {
        inputField.text = "";
        inputField.ActivateInputField();
        targetText.text = codeLines[currentIndex];
        feedbackText.text = "";
    }

    void CheckAnswer(string input)
    {
        if (input.Trim() == codeLines[currentIndex])
        {
            correctCount++;
            feedbackText.text = "Correct!";
            currentIndex = (currentIndex + 1) % codeLines.Length;

            if (correctCount >= totalwords)
            {
                feedbackText.text = "All lines completed!";
                inputField.interactable = false;
                gameObject.SetActive(false);
                FindObjectOfType<ObjectiveManager>()?.CompleteObjective(1);
                return;
            }

            Invoke(nameof(ShowNewLine), 1f);
        }
        else
        {
            feedbackText.text = "Try again";
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
}
