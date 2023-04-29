using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsCanvas : MonoBehaviour
{
    //Static Object Instance//
    public static OptionsCanvas Instance { get; private set; }
    //Slider Object References//
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] GameObject mainMenuButton;
    public delegate void OnVolumeChangeDelegate();
    public event OnVolumeChangeDelegate OnVolumeChange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        Instance.gameObject.SetActive(false);
    }
    
    public void XButtonPressed()
    {
        Instance.gameObject.SetActive(false);
    }
    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", Instance.musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", Instance.sfxVolumeSlider.value);
        if(OnVolumeChange!=null)
            OnVolumeChange();
    }

    private void OnEnable()
    {
        Instance.musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        Instance.sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        gameObject.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex==1)
            mainMenuButton.SetActive(true);
        else mainMenuButton.SetActive(false);
    }
}
