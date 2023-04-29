using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFunctions : MonoBehaviour
{
    OptionsCanvas optsCanvas;
    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        optsCanvas=FindObjectOfType<OptionsCanvas>(includeInactive:true);
    }
    public void StartButtonPress()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OptionsButtonPress()
    {
        optsCanvas.gameObject.SetActive(true);
    }
}
