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
        public string title;
        public string desc;
        public Sprite image;
        public bool isSafe; // true = right swipe is correct
    }
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image siteImage;
    public Button leftButton;
    public Button rightButton;


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
                FindObjectOfType<ObjectiveManager>()?.CompleteObjective(2);

            gameObject.SetActive(false);
            return;
        }

        WebsiteCard card = cards[currentIndex];
        titleText.text = card.title;

        descriptionText.text = card.desc;

        if (siteImage != null && card.image != null)
            siteImage.sprite = card.image;
        else if (siteImage != null)
            siteImage.enabled = false;
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
