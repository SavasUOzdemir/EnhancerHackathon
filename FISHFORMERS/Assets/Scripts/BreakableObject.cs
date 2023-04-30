using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField]int hitPoints = 3;
    SpriteRenderer spriteRenderer;
    int color_g = 255;
    int color_b = 255;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Hit!");
            hitPoints--;
            if (hitPoints == 0)
            { Destroy(gameObject); return; }
            color_b -= 255 / (hitPoints +1);
            color_g -= 255 / (hitPoints +1);
            spriteRenderer.color = new Color(255, color_g, color_b);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Weapon"))
    //    {
    //        Debug.Log("Hit!");
    //        hitPoints--;
    //        if (hitPoints == 0)
    //            Destroy(gameObject);
    //        color_b -= 255/hitPoints;
    //        color_g -= 255/hitPoints;
    //        spriteRenderer.color = new Color(255, color_g, color_b);
    //    }
        
    
}
