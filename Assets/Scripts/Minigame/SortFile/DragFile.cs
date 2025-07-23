using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFile : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;
    public SortfileMinigame manager;
    // void Start()
    // {
    //     manager = FindObjectOfType<SortfileMinigame>();
    // }
    void OnMouseDown()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
        dragging = true;
    }

    void OnMouseDrag()
    {
        if (dragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + offset;
        }
    }

    void OnMouseUp()
    {
        dragging = false;
    }

//     void OnDestroy()
//     {
//         if (manager != null)
//             manager.FileSorted();
//     }
}