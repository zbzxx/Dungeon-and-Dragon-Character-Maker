using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuObserver : MonoBehaviour
{
    [SerializeField] private Button createCharacterButton;
    [SerializeField] private Button loadCharacterButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        // Check if there are saved characters and enable/disable Load button accordingly
        if (PlayerPrefs.HasKey("CharacterCount") && PlayerPrefs.GetInt("CharacterCount") > 0)
        {
            loadCharacterButton.interactable = true;
        }
        else
        {
            loadCharacterButton.interactable = false;
        }

        createCharacterButton.onClick.AddListener(CreateCharacter);
        loadCharacterButton.onClick.AddListener(LoadCharacter);
        settingButton.onClick.AddListener(OpenSettings);
        exitButton.onClick.AddListener(QuitGame);
    }
    private void CreateCharacter()
    {
        // Load the character creation scene
        SceneManager.LoadScene("CharacterCreator");
    }

    private void LoadCharacter()
    {
        // Load the character selection scene
        SceneManager.LoadScene("CharacterSelection");
    }

    private void OpenSettings()
    {
        // Open the settings menu
        SceneManager.LoadScene("Setting"); 
    }

    private void QuitGame()
    {
        // Quit the game
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}
