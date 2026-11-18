using System;
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
    [SerializeField] private Notifications notifications;
    private bool isShown = false;
    
    public static Action <int> OnCompleteObjective;

    void Start()
    {
        OnCompleteObjective = CompleteObjective;
        
        completed = new bool[objectives.Length];
        completedCount = objectives.Length;

        for (int i = 0; i < objectiveTexts.Length && i < objectives.Length; i++)
        {
            objectiveTexts[i].text = $"Objective {i + 1}: {objectives[i]}";
        }
    }
    void Update()
    {
    }

    public void CompleteObjective(int index)
    {
        completedCount--;
        Debug.Log($"completed count: {completedCount}");
        if (completedCount <= 0 && !isShown)
        {
            isShown = true;
            nextDialog.SetActive(true);
            return;
        }
        
        if (index >= 0 && index < objectiveTexts.Length && !completed[index])
        {
            completed[index] = true;

            string rawText = objectiveTexts[index].text;
            rawText = rawText.Replace("<s>", "").Replace("</s>", "");

            objectiveTexts[index].text = $"<s>{rawText}</s>";
        }
        notifications.PopNotif();
    }
}
