using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5Video : MonoBehaviour
{
    public GameObject video; // Assign the button you want to enable in the inspector
    public float delay = 10f; // 60 seconds = 1 minute
    private static bool hasLevelBeenPlayed = false; // Static flag to track if the level has been played

    // Start is called before the first frame update
    void Start()
    {
        if (!hasLevelBeenPlayed)
        {
            video.gameObject.SetActive(true);
            Invoke("Disablevideo", delay);
            hasLevelBeenPlayed = true;
        }
        else
        {
            video.gameObject.SetActive(false);
        }
    }

    // A Coroutine that will disable the GameObject after a delay
    private void Disablevideo()
    {
        // Disable the GameObject
        video.gameObject.SetActive(false);
    }
}
