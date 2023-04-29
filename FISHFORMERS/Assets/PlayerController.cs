using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Move player
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
        if (movement!=Vector2.zero)
        {
            transform.right = movement / moveSpeed;
        }
        rb2d.velocity = movement;
    }
}
