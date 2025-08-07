using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortfileMinigame : MonoBehaviour
{
    public GameObject[] filePrefabs;
    public int fileCount = 10;
    public RectTransform spawnArea;
    private int remainingFiles;
    public Button button;

    void OnEnable()
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

            RectTransform fileRT = file.AddComponent<RectTransform>();

            fileRT.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            float width = spawnArea.rect.width;
            float height = spawnArea.rect.height;

            float x = Random.Range(-width / 2, width / 2);
            float y = Random.Range(-height / 2, height / 2);

            fileRT.anchoredPosition = new Vector2(x, y);
        }
    }

    public void FileSorted()
    {
        remainingFiles--;

        if (remainingFiles <= 0)
        {
            button.interactable = false;
            FindObjectOfType<ObjectiveManager>().CompleteObjective(0);
            gameObject.SetActive(false);
        }
    }
}
