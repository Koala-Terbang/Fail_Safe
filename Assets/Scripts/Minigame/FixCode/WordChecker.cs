using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordChecker : MonoBehaviour
{
    public ClickableWord[] allWords;
    public int falsed;
    public GameObject typing;
    void Start()
    {
        falsed = allWords.Length;
    }
    void Update()
    {
        if (falsed <= 0)
        {
            gameObject.SetActive(false);
            typing.SetActive(true);
        }
    }
}
