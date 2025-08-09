using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SwipingMinigame : MonoBehaviour
{
    [System.Serializable]
    public class WebsiteCard
    {
        public string title;
        public string publish;
        public string desc;
        public Sprite image;
        public bool isSafe;
    }
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI publishText;
    public Image siteImage;
    public Button leftButton;
    public Button rightButton;
    public Button desktopButton;

    public WebsiteCard[] cards;
    private int currentIndex = 0;
    private int correctAnswers = 0;
    private int neededCorrect;
    public AudioClip swipeRightSFX;
    public AudioClip swipeLeftSFX;

    void Start()
    {
        neededCorrect = cards.Length;
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
                FindObjectOfType<Notifications>().PopNotif();
                gameObject.SetActive(false);
            }
            currentIndex = 0;
            correctAnswers = 0;
            return;
        }

        WebsiteCard card = cards[currentIndex];
        titleText.text = card.title;
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
            currentIndex++;
        }
        else
        {
            FindObjectOfType<TryAgain>().tryAgain();
        }
        ShowCurrentCard();
    }
    void PlaySwipeSFX(bool swipedRight)
    {
        if (swipedRight)
            AudioManager.I.PlaySFX(swipeRightSFX);
        else
            AudioManager.I.PlaySFX(swipeLeftSFX);
    }
}
