using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockTransformation : MonoBehaviour
{
    [SerializeField] int transformationValue = -1; //0 for default, 1 for small, 2 for mid, 3 for large
    [SerializeField] GameObject[] unlockIcons;
    [SerializeField] TMP_Text unlockText;
    bool unlockTextActivatedOnce = false;
    TransformationHandler handler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || unlockTextActivatedOnce) return;
        handler= collision.gameObject.GetComponent<TransformationHandler>();
        try
        {
            unlockIcons[transformationValue - 1].gameObject.SetActive(true);
            switch (transformationValue)
            {
                case 0:
                    unlockText.text = "Default State";
                    break;
                case 1:
                    unlockText.text = "Small Fish Unlocked!";
                    handler.TransformOneEnabled = true;
                    break;
                case 2:
                    unlockText.text = "Middle Fish Unlocked!";
                    handler.TransformTwoEnabled = true;
                    break;
                case 3:
                    unlockText.text = "Large Fish Unlocked!";
                    handler.TransformThreeEnabled = true;
                    break;
                default: break;
            }
            unlockText.gameObject.SetActive(true);
            unlockTextActivatedOnce = true;
        }
        catch (System.Exception)
        {
            Debug.Log("check transformation object");
        }
        
    }

    
}
