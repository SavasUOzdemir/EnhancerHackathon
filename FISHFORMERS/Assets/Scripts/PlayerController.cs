using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private OptionsCanvas optionsCanvas;
    Vector2 movement;

    private void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>(includeInactive: false);
        sr = GetComponentInChildren<SpriteRenderer>(includeInactive: false);
        optionsCanvas = FindObjectOfType<OptionsCanvas>(includeInactive: true);

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
            transform.right = movement / moveSpeed;
        OrientSpriteRenderer();
        if (Input.GetKeyDown(KeyCode.Escape)) { optionsCanvas.gameObject.SetActive(!optionsCanvas.gameObject.activeSelf); }
    }

    void OrientSpriteRenderer()
    {
        if ((transform.rotation.eulerAngles.z >= 135 && transform.rotation.eulerAngles.z < 180) || (transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z <= 225))
            sr.flipY = true;
        else sr.flipY = false;
    }
}

