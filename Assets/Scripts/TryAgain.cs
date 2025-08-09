using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgain : MonoBehaviour
{
    public GameObject panel;
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
