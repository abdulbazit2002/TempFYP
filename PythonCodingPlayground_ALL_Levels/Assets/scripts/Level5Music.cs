using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Music : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Background2");
        audioSource.volume = 0.4f;
        audioSource.loop = true;
        audioSource.Play();
    }
}
