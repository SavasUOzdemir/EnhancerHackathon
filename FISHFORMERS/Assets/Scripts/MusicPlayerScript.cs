using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    OptionsCanvas optionsCanvas;
    private void Awake()
    {
        optionsCanvas = FindObjectOfType<OptionsCanvas>(includeInactive:true);
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void OnEnable()
    {
        optionsCanvas.OnVolumeChange += ChangeVolume;
    }

    private void OnDisable()
    {
        optionsCanvas.OnVolumeChange -= ChangeVolume;

    }
    void ChangeVolume()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
