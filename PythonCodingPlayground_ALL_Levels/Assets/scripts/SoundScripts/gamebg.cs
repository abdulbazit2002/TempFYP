using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamebg : MonoBehaviour
{
    public void MutedToggleBackgroundMusic()
    {
        SoundManager.instance.ToggleBackgroundMusic();
    }
    public void MutedToggleSound()
    {
        SoundManager.instance.ToggleSoundfx();
    }
}
