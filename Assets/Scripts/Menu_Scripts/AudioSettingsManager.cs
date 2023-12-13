using UnityEngine;
using UnityEngine.UI; // Required for UI components like Slider

public class AudioSettingsManager : MonoBehaviour
{
    public AudioSource audioSource; // Assign this in the inspector
    public Slider volumeSlider;     // Assign the volume slider in the inspector

    private void Start()
    {
        // Initialize the slider's value to the current volume
        volumeSlider.value = audioSource.volume;

        // Add a listener to handle the value change events
        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
    }

    private void HandleVolumeChange(float value)
    {
        // Set the volume on the AudioSource to the slider's value
        audioSource.volume = value;
    }
}
