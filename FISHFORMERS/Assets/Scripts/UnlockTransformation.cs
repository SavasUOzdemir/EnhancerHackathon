using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockTransformation : MonoBehaviour
{
    [SerializeField] int transformationValue = -1; //0 for default, 1 for small, 2 for mid, 3 for large
    [SerializeField] GameObject[] unlockIcons;
    bool unlockTextActivatedOnce = false;
    SpriteRenderer spriteRenderer;
    TransformationHandler handler;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(includeInactive:true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || unlockTextActivatedOnce) return;
        handler= collision.gameObject.GetComponent<TransformationHandler>();
        try
        {
           spriteRenderer.gameObject.SetActive(true);
            unlockIcons[transformationValue - 1].gameObject.SetActive(true);
            switch (transformationValue)
            {
                case 0:
                    break;
                case 1:
                    handler.TransformOneEnabled = true;
                    break;
                case 2:
                    handler.TransformTwoEnabled = true;
                    break;
                case 3:
                    handler.TransformThreeEnabled = true;
                    break;
                default: break;
            }
            unlockTextActivatedOnce = true;
        }
        catch (System.Exception)
        {
            Debug.Log("check transformation object");
        }
        
    }

    
}
