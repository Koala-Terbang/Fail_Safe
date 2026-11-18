using System.Collections;
using System;
using UnityEngine;

public class TryAgain : MonoBehaviour
{
    public GameObject panel;
    
    public static Action OnFailedMinigame;

    void Start()
    {
        OnFailedMinigame = tryAgain;
    }
    public void tryAgain()
    {
        StartCoroutine(Try());
    }
    IEnumerator Try()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(false);
    }
}
