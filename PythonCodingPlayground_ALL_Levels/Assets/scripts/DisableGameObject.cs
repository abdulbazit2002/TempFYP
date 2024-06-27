using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour
{
    public GameObject video; // Assign the button you want to enable in the inspector
    public float delay = 10f; // 60 seconds = 1 minut
    // Start is called before the first frame update
    void Start()
    {
        // Start a Coroutine that will run for 10 seconds
        // before disabling the GameObject
        video.gameObject.SetActive(true);
        Invoke("Disablevideo", delay);
    }

    // A Coroutine that will disable the GameObject after a delay
    private void Disablevideo()
    {

        // Disable the GameObject
        video.gameObject.SetActive(false);
    }
}