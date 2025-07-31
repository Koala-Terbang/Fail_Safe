using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ComicIntro : MonoBehaviour
{
    [System.Serializable]
    public class Slide
    {
        public Sprite image;
        [TextArea] public string caption;
    }

    public Slide[] slides;
    public Image sceneImage;
    public TextMeshProUGUI dialogueText;

    private int currentIndex = 0;

    void Start()
    {
        ShowSlide(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            currentIndex++;
            if (currentIndex < slides.Length)
            {
                ShowSlide(currentIndex);
            }
            else
            {
                EndIntro();
            }
        }
    }

    void ShowSlide(int index)
    {
        sceneImage.sprite = slides[index].image;
        dialogueText.text = slides[index].caption;
    }

    void EndIntro()
    {
        Debug.Log("Intro complete!");
        // TODO: Load next scene, enable UI, etc.
        gameObject.SetActive(false);
    }
}
