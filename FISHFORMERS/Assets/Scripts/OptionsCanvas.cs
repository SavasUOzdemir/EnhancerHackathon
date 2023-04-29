using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvas : MonoBehaviour
{
    //Static Object Instance//
    public static OptionsCanvas Instance { get; private set; }
    //Slider Object References//
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    public delegate void OnVolumeChangeDelegate();
    public event OnVolumeChangeDelegate OnVolumeChange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void XButtonPressed()
    {
        gameObject.SetActive(false);
    }
    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        OnVolumeChange();
    }

    private void OnEnable()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
