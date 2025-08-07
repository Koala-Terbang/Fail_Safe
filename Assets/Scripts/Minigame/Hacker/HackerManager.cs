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
    public Button button;

    void Awake() => Instance = this;

    public void StartDragTrace(PC target)
    {
        tracedPC = target;
        isDragging = true;
        Debug.Log("Started dragging from wire to: " + target.name);
    }

    void Update()
    {
        if (totalHacker <= 0)
        {
            FindObjectOfType<ObjectiveManager>()?.CompleteObjective(0);
            button.interactable = false;
            gameObject.SetActive(false);
        }  
        if (isDragging && Input.GetMouseButtonUp(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null)
                {
                    PC releasedOn = hit.collider.GetComponent<PC>();

                    if (releasedOn != null)
                    {
                        if (releasedOn == tracedPC)
                        {
                            if (releasedOn.type == PCType.Hacker)
                            {
                                Debug.Log("Hacker found.");
                                totalHacker--;
                            }
                            else
                                Debug.Log("That's a Worker.");

                        }
                    }
                }
                tracedPC = null;
                isDragging = false;
            }
    }
}
