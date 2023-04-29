using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerStats = collision.gameObject.GetComponent<PlayerStats>();
            playerStats.RespawnCoordinates = gameObject.transform.position;
        }
    }
}
