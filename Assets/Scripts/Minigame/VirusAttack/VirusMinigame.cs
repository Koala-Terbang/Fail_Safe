using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMinigame : MonoBehaviour
{
    public GameObject[] insectPrefabs;
    public Transform target;
    public int insectCount = 5;
    private Bounds spawnBounds;
    private float spawnInterval = 0.5f;
    public int VirusAlive = 5;
    public GameObject panel;

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
        Vector2 spawnPos = new Vector2(
            Random.Range(spawnBounds.min.x, spawnBounds.max.x),
            Random.Range(spawnBounds.min.y, spawnBounds.max.y)
        );

        int index = Random.Range(0, insectPrefabs.Length);
        GameObject virus = Instantiate(insectPrefabs[index], spawnPos, Quaternion.identity);
        Virus ai = virus.GetComponent<Virus>();
        ai.SetTarget(target);
        ai.SetSpawner(this);
    }
}
