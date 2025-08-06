using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public string acceptedTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(acceptedTag))
        {
            SortfileMinigame manager = FindObjectOfType<SortfileMinigame>();
            manager.FileSorted();
            other.gameObject.SetActive(false);
            Destroy(other.gameObject, 0.05f);
        }
    }
}