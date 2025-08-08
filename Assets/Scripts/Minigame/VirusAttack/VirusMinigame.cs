using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusMinigame : MonoBehaviour
{
    public GameObject[] insectPrefabs;
    public Transform target;
    public int insectCount = 5;
    private Bounds spawnBounds;
    private float spawnInterval = 0.5f;
    public int VirusAlive = 5;
    public GameObject panel;
    public Button button;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spawnBounds = sr.bounds;
        VirusAlive = insectCount;
        StartCoroutine(SpawnVirusOverTime());
    }

    void Update()
    {
        if (VirusAlive == 0)
        {
            panel.SetActive(false);
            FindObjectOfType<ObjectiveManager>()?.CompleteObjective(0);
            button.interactable = false;
        }
    }
    IEnumerator SpawnVirusOverTime()
    {
        for (int i = 0; i < insectCount; i++)
        {
            SpawnRandomInsect();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomInsect()
{
    float minDistance = 2f;
    float maxDistance = 5f;

    Vector2 spawnPos;
    int safety = 0;

    do
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float distance = Random.Range(minDistance, maxDistance);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        spawnPos = (Vector2)target.position + direction * distance;

        safety++;
        if (safety > 100)
            break;
    }
    while (!spawnBounds.Contains(spawnPos));

    int index = Random.Range(0, insectPrefabs.Length);
    GameObject virus = Instantiate(insectPrefabs[index], spawnPos, Quaternion.identity);
    Virus ai = virus.GetComponent<Virus>();
    ai.SetTarget(target);
    ai.SetSpawner(this);
}
}
