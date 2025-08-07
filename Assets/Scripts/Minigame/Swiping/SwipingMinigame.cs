using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SwipingMinigame : MonoBehaviour
{
    [System.Serializable]
    public class WebsiteCard
    {
        public string publish;
        public string desc;
        public Sprite image;
        public bool isSafe;
    }
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI publishText;
    public Image siteImage;
    public Button leftButton;
    public Button rightButton;
    public Button desktopButton;

    public WebsiteCard[] cards;
    private int currentIndex = 0;
    private int correctAnswers = 0;
    public int neededCorrect = 5;

    void Start()
    {
        leftButton.onClick.AddListener(() => OnSwipe(false));
        rightButton.onClick.AddListener(() => OnSwipe(true));
        ShowCurrentCard();
    }

    void ShowCurrentCard()
    {
        if (currentIndex >= cards.Length)
        {
            if (correctAnswers >= neededCorrect)
            {
                desktopButton.interactable = false;
                FindObjectOfType<ObjectiveManager>()?.CompleteObjective(2);
            }

            gameObject.SetActive(false);
            return;
        }

        WebsiteCard card = cards[currentIndex];
        descriptionText.text = card.desc;
        publishText.text = card.publish;
        siteImage.sprite = card.image;
    }

    void OnSwipe(bool swipedRight)
    {
        WebsiteCard card = cards[currentIndex];

        bool isCorrect = (swipedRight == card.isSafe);
        if (isCorrect)
        {
            correctAnswers++;
        }
        else
        {
        }

        currentIndex++;
        ShowCurrentCard();
    }
}
