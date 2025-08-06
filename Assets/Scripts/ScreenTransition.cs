using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    public GameObject[] frames;
    public float[] frameDurations;

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i].SetActive(true);

            if (i > 0) frames[i - 1].SetActive(false);

            yield return new WaitForSeconds(frameDurations[i]);
        }
    }
}
