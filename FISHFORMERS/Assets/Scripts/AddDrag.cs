using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDrag : MonoBehaviour
{
    [SerializeField] Vector2 dragRotation;
    [SerializeField] float dragForce;
    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D other_rb2d = other.gameObject.GetComponent<Rigidbody2D>();
        other_rb2d.AddForce(dragRotation * dragForce,ForceMode2D.Force);
        Debug.Log("ontriggerstay");
    }
}
