using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPrefab;
    public RectTransform popupArea;
    public int popupCount = 10;
    private int remainingPopups;
    public GameObject Glitch;

    public void StartPopupGame()
    {
        ClearPopups();
        remainingPopups = popupCount;

        for (int i = 0; i < popupCount; i++)
        {
            GameObject popup = Instantiate(popupPrefab, popupArea);
            RectTransform popupRT = popup.GetComponent<RectTransform>();

            popupRT.localScale = Vector3.one;

            popupRT.pivot = new Vector2(0.5f, 0.5f);

            float popupWidth = popupRT.rect.width;
            float popupHeight = popupRT.rect.height;

            float areaWidth = popupArea.rect.width;
            float areaHeight = popupArea.rect.height;

            float x = Random.Range(-areaWidth / 2 + popupWidth / 2, areaWidth / 2 - popupWidth / 2);
            float y = Random.Range(-areaHeight / 2 + popupHeight / 2, areaHeight / 2 - popupHeight / 2);
            popupRT.anchoredPosition = new Vector2(x, y);

            popup.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                Destroy(popup);
                remainingPopups--;
                if (remainingPopups <= 0)
                    BreakPC();
            });
        }
    }

    void ClearPopups()
    {
        foreach (Transform child in popupArea)
            Destroy(child.gameObject);
    }

    void BreakPC()
    {
        Glitch.SetActive(true);
    }
}
