using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortfileMinigame : MonoBehaviour
{
    public GameObject[] filePrefabs;
    public int fileCount = 10;
    public RectTransform spawnArea;
    private int remainingFiles;

    void Start()
    {
        SpawnFiles();
    }
    void SpawnFiles()
    {
        remainingFiles = fileCount;

        for (int i = 0; i < fileCount; i++)
        {
            int index = Random.Range(0, filePrefabs.Length);
            GameObject file = Instantiate(filePrefabs[index], spawnArea);

            RectTransform fileRT = file.GetComponent<RectTransform>();

            fileRT = file.AddComponent<RectTransform>();

            fileRT.localScale = Vector3.one;

            float width = spawnArea.rect.width;
            float height = spawnArea.rect.height;

            float x = Random.Range(-width / 2, width / 2);
            float y = Random.Range(-height / 2, height / 2);

            fileRT.anchoredPosition = new Vector2(x, y);
        }
    }

    // public void FileSorted()
    // {
    //     remainingFiles--;

    //     if (remainingFiles <= 0)
    //     {
    //         Debug.Log("All files sorted!");

    //         MinigameSelector selector = FindObjectOfType<MinigameSelector>();
    //         if (selector != null)
    //             selector.StartRandomMinigame();

    //         gameObject.SetActive(false);
    //     }
    // }

}
