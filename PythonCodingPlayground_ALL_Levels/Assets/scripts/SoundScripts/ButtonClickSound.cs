using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buttonClickSound;
        audioSource.volume = 0.5f; // Set the volume to 0.5
    }

    public void PlayButtonClickSound()
    {
        audioSource.Play();
    }
}