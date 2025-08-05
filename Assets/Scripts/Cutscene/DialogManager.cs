using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        [TextArea] public string text;
        public Sprite characterSprite;
        public Sprite backgroundSprite;
    }
    public DialogueLine[] lines;
    public Image backgroundImage;
    public Image characterImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject PCZoom;

    private int currentIndex = 0;

    void Start()
    {
        ShowLine(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex++;
            if (currentIndex < lines.Length)
                ShowLine(currentIndex);
            else
                EndDialogue();
        }
    }

    void ShowLine(int index)
    {
        DialogueLine line = lines[index];
        nameText.text = line.speakerName;
        dialogueText.text = line.text;

        if (line.characterSprite != null)
            characterImage.sprite = line.characterSprite;

        if (line.backgroundSprite != null)
            backgroundImage.sprite = line.backgroundSprite;
    }

    void EndDialogue()
    {
        gameObject.SetActive(false);
        PCZoom.SetActive(true);
    }
}
