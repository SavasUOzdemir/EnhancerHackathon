using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockTransformation : MonoBehaviour
{
    [SerializeField] int transformationValue = -1; //0 for default, 1 for small, 2 for mid, 3 for large
    [SerializeField] GameObject[] unlockIcons;
    [SerializeField] TMP_Text unlockText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
                    break;
                case 2:
                    unlockText.text = "Middle Fish Unlocked!";
                    break;
                case 3:
                    unlockText.text = "Large Fish Unlocked!";
                    break;
                default: break;
            }
            unlockText.gameObject.SetActive(true);
        }
        catch (System.Exception)
        {
            Debug.Log("check transformation object");
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && Input.GetKey(KeyCode.E))
        {
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject.SendMessage("TransformCharacter", transformationValue);
        }
    }
}
