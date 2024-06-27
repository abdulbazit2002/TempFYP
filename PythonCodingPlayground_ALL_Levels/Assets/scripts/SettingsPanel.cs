using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    //public Slider musicSlider;
    //public Slider soundSlider;
    public Button backButton;

    private void Start()
    {
        // Load saved settings
       // musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        //soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);

        // Add listeners to sliders and button
        //musicSlider.onValueChanged.AddListener(SetMusicVolume);
        //soundSlider.onValueChanged.AddListener(SetSoundVolume);
        backButton.onClick.AddListener(CloseSettings);
    }

   /* private void SetMusicVolume(float volume)
    {
        // Set music volume (you would need to implement this based on your audio system)
        Debug.Log("Music Volume set to: " + volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private void SetSoundVolume(float volume)
    {
        // Set sound volume (you would need to implement this based on your audio system)
        Debug.Log("Sound Volume set to: " + volume);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }*/

    private void CloseSettings()
    {
        // Deactivate the settings panel
        gameObject.SetActive(false);
    }
}
