using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMinigame : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D rb;
    public GameObject panel;
    public GameObject viruspanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    public void SetDirection(string direction)
    {
        switch (direction)
        {
            case "up": moveDirection = Vector2.up; break;
            case "down": moveDirection = Vector2.down; break;
            case "left": moveDirection = Vector2.left; break;
            case "right": moveDirection = Vector2.right; break;
        }
    }

    public void StopDirection()
    {
        moveDirection = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            panel.SetActive(false);
            viruspanel.SetActive(true);
        }
    }
}
