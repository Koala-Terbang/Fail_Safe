using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickableWord : MonoBehaviour
{
    public bool isWrongWord = false;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (isWrongWord)
        {
            text.text = $"<u><color=red>{text.text}</color></u>";
        }
    }

    public void ButtonClicked()
    {
        if (isWrongWord)
        {
            isWrongWord = false;
            text.text = text.text.Replace("<u><color=red>", "").Replace("</color></u>", "");
            gameObject.SetActive(false);
            FindObjectOfType<WordChecker>().falsed--;
        }
    }
}