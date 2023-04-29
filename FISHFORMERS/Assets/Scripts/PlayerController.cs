using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb2d;
    Vector2 movement;

    private void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>(includeInactive:false);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = movement;
    }
    private void Update()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Move player
        movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
        if (movement != Vector2.zero)
        {
            transform.right = movement / moveSpeed;
        }
    }
}
