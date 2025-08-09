using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        [TextArea] public string text;
        public Sprite characterSprite;
        public Sprite backgroundSprite;
        public AudioClip audioClip;
    }
    public DialogueLine[] lines;
    public Image backgroundImage;
    public Image characterImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject PCZoom;
    public string nextScene;

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
                StartCoroutine(ShowLine(currentIndex));
            else
                EndDialogue();
        }
    }

    IEnumerator ShowLine(int index)
    {
        DialogueLine line = lines[index];
        nameText.text = line.speakerName;
        dialogueText.text = line.text;

        if (line.audioClip != null)
            AudioManager.I?.PlaySFX(line.audioClip);

        yield return new WaitForSeconds(0.5f);

        if (line.characterSprite != null)
        {
            characterImage.sprite = line.characterSprite;
            characterImage.gameObject.SetActive(true);
        }
        else
        {
            characterImage.gameObject.SetActive(false);
        }

        backgroundImage.sprite = line.backgroundSprite;
    }

    void EndDialogue()
    {
        gameObject.SetActive(false);

        if (nextScene == "null")
        {
            PCZoom.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
