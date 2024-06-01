using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSetting : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private void Start()
    {
        // Load saved preferences
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }

        // Set initial volumes
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        AudioManager.Instance.SetMusicVolume(musicVolumeSlider.value);
        AudioManager.Instance.SetSFXVolume(sfxVolumeSlider.value);

        // Add listeners to buttons
        saveButton.onClick.AddListener(SavePreferences);
        backButton.onClick.AddListener(BackToMainMenu);
    }

    private void SavePreferences()
    {
        // Save user preferences
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        PlayerPrefs.Save();
        Debug.Log("Preferences saved");
    }

    private void OnMusicVolumeChanged(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }

    private void OnSFXVolumeChanged(float volume)
    {
        AudioManager.Instance.SetSFXVolume(volume);
    }
    private void BackToMainMenu()
    {
        // Return to the main menu
        SceneManager.LoadScene("Menu");
    }
}
