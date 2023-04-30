using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableObject : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DisableAfterSeconds(5));
    }

    IEnumerator DisableAfterSeconds(int waittime)
    {
        yield return new WaitForSeconds(waittime);
        gameObject.SetActive(false);
        yield break;
    }
}
