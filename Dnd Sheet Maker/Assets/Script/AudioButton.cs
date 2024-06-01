using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public AudioClip buttonClickSound; // The sound to play on button click
    void Start()
    {
        // Get the button component attached to this GameObject
        Button button = GetComponent<Button>();

        if (button != null)
        {
            // Add a listener to the button to play the sound when clicked
            button.onClick.AddListener(PlayButtonClickSound);
        }
    }

    private void PlayButtonClickSound()
    {
        if (AudioManager.Instance != null && buttonClickSound != null)
        {
            AudioManager.Instance.PlaySFX(buttonClickSound);
        }
    }
}
