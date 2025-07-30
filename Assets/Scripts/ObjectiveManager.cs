using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI[] objectiveTexts;
    public string[] objectives = new string[]
    {
        "Sort out the files (File App)",
        "Select reliable passwords (Password App)",
        "Read the news feed (News App)",
        "Connect the correlating wires (Network App)"
    };

    private bool[] completed;

    void Start()
    {
        completed = new bool[objectives.Length];

        for (int i = 0; i < objectiveTexts.Length && i < objectives.Length; i++)
        {
            objectiveTexts[i].text = $"Objective {i + 1}: {objectives[i]}";
        }
    }

    public void CompleteObjective(int index)
    {
        if (index >= 0 && index < objectiveTexts.Length && !completed[index])
        {
            completed[index] = true;

            string rawText = objectiveTexts[index].text;
            rawText = rawText.Replace("<s>", "").Replace("</s>", "");

            objectiveTexts[index].text = $"<s>{rawText}</s>";
        }
    }
}
