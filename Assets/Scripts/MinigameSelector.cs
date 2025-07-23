using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSelector : MonoBehaviour
{
    public GameObject[] minigames;
    private GameObject currentMinigame;

    public void StartRandomMinigame()
    {
        if (currentMinigame != null)
            currentMinigame.SetActive(false);

        int index = Random.Range(0, minigames.Length);
        currentMinigame = minigames[index];
        currentMinigame.SetActive(true);

        if (currentMinigame.name.Contains("Popup"))
        {
            PopupManager popup = currentMinigame.GetComponent<PopupManager>();
            if (popup != null)
                popup.StartPopupGame();
        }
    }

    public void EndMinigame()
    {
        if (currentMinigame != null)
        {
            currentMinigame.SetActive(false);
            currentMinigame = null;
        }
    }
}
