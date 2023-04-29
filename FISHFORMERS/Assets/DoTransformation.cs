using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTransformation : MonoBehaviour
{
    FollowItem followItem;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        followItem = FindObjectOfType<FollowItem>(includeInactive: true);
        followItem.followTarget = gameObject.transform;
        followItem.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            followItem.gameObject.SetActive(false);
    }
}
