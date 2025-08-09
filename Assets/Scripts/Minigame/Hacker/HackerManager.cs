using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackerManager : MonoBehaviour
{
    public static HackerManager Instance;

    private PC tracedPC;
    private bool isDragging = false;
    public int totalHacker = 3;
    public GameObject IPpanel;
    void Awake() => Instance = this;

    public void StartDragTrace(PC target)
    {
        tracedPC = target;
        isDragging = true;
    }

    void Update()
    {
        if (totalHacker <= 0)
        {
            IPpanel.SetActive(true);
            gameObject.SetActive(false);

        }  
        if (isDragging && Input.GetMouseButtonUp(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            
                PC releasedOn = hit.collider.GetComponent<PC>();
                if (releasedOn == tracedPC)
                {
                    if (releasedOn.type == PCType.Hacker)
                    {
                        totalHacker--;
                    }
                    else
                        FindObjectOfType<TryAgain>().tryAgain();
                }
                tracedPC = null;
                isDragging = false;
            }
    }
}
