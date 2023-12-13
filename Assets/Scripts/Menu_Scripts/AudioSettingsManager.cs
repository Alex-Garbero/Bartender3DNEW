using UnityEngine;
using UnityEngine.UI; // Required for interacting with UI elements

public class AudioSettingsManager : MonoBehaviour
{
    // Reference to the audio source that controls the game's music
    public AudioSource musicSource;

    // Function that will be called when the slider value changes
    public void OnVolumeSliderChanged(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }
}
