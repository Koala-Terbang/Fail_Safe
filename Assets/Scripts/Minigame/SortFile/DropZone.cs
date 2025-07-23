using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public string acceptedTag; // "GoodFile" or "BadFile"

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(acceptedTag))
        {
            // SortfileMinigame manager = FindObjectOfType<SortfileMinigame>();
            // if (manager != null)
            //     manager.FileSorted();
            // other.gameObject.SetActive(false);
            Destroy(other.gameObject, 0.05f);
        }
        else if (other.CompareTag("GoodFile") || other.CompareTag("BadFile"))
        {
            Debug.Log("Incorrect file dropped!");
        }
    }
}