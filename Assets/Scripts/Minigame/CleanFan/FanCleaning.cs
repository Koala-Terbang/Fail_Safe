using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCleaning : MonoBehaviour
{
    public GameObject dirtPrefab;
    public Transform spawnArea;
    public int dirtCount = 10;
    private int remainingDirt;
    public GameObject Glitch;

    void OnEnable()
    {
        SpawnDirt();
    }

    void SpawnDirt()
    {
        remainingDirt = dirtCount;

        for (int i = 0; i < dirtCount; i++)
        {
            GameObject dirt = Instantiate(dirtPrefab, spawnArea);
            dirt.transform.localPosition = GetRandomPosition();
        }
    }

    Vector3 GetRandomPosition()
    {
        RectTransform rt = spawnArea.GetComponent<RectTransform>();
        float width = rt.rect.width;
        float height = rt.rect.height;

        float x = Random.Range(-width / 2f, width / 2f);
        float y = Random.Range(-height / 2f, height / 2f);
        return new Vector3(x, y, 0);
    }

    public void DirtCleaned()
    {
        remainingDirt--;

        if (remainingDirt <= 0)
        {
            Glitch.SetActive(false);
        }
    }
}
