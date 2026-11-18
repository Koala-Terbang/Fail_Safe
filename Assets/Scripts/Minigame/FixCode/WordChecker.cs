using System.Collections;
using System;
using UnityEngine;

public class WordChecker : MonoBehaviour
{
    public ClickableWord[] allWords;
    public int falsed;
    public GameObject typing;
    
    public static Action OnWordClicked;
    
    void Start()
    {
        OnWordClicked = WordClick;
        falsed = allWords.Length;
    }
    
    void WordClick()
    {
        falsed--;
        
        if (falsed <= 0)
        {
            gameObject.SetActive(false);
            typing.SetActive(true);
        }
    }
}
