using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTriggerStay : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] float damageInterval = 1f;

    PlayerStats playerStats;
    Coroutine damageCoroutine;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damageCoroutine = StartCoroutine(DealDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(damageCoroutine);
        }
    }

    IEnumerator DealDamage()
    {
        while (true)
        {
            playerStats.HitPoints -= damageAmount;
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
