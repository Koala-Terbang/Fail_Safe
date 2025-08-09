using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainUtils;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI[] objectiveTexts;
    public string[] objectives;
    private bool[] completed;
    private int completedCount;
    public GameObject nextDialog;
    private bool isShown = false;

    void Start()
    {
        completed = new bool[objectives.Length];
        completedCount = objectives.Length;

        for (int i = 0; i < objectiveTexts.Length && i < objectives.Length; i++)
        {
            objectiveTexts[i].text = $"Objective {i + 1}: {objectives[i]}";
        }
    }
    void Update()
    {
        if (completedCount <= 0 && !isShown)
        {
            isShown = true;
            nextDialog.SetActive(true);
        }
    }

    public void CompleteObjective(int index)
    {
        completedCount--;
        if (index >= 0 && index < objectiveTexts.Length && !completed[index])
        {
            completed[index] = true;

            string rawText = objectiveTexts[index].text;
            rawText = rawText.Replace("<s>", "").Replace("</s>", "");

            objectiveTexts[index].text = $"<s>{rawText}</s>";
        }
    }
}
