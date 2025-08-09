using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public float speed = 2f;
    private Transform target;
    private VirusMinigame spawner;
    private GameObject panel;

    public void SetTarget(Transform t)
    {
        target = t;
    }
    public void SetSpawner(VirusMinigame s)
    {  
        spawner = s;
    }

    public void Start()
    {
        panel = GameObject.FindGameObjectWithTag("VirusMinigame");
    }
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        FindObjectOfType<TryAgain>().tryAgain();
        panel.SetActive(false);
        GameObject[] allViruses = GameObject.FindGameObjectsWithTag("Virus");
        foreach (GameObject virus in allViruses)
        {
            Destroy(virus);
        }
    }

    void OnMouseDown()
    {
        spawner.VirusAlive--;
        spawner.SFXKill();
        Destroy(gameObject);
    }
}
