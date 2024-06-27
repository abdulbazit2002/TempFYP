using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnableButtonAfterDelay : MonoBehaviour
{
    public Button buttonToEnable; // Assign the button you want to enable in the inspector
    public float delay = 60f; // 60 seconds = 1 minute

    private void Start()
    {
        // Disable and hide the button initially
        buttonToEnable.interactable = false;
        buttonToEnable.gameObject.SetActive(false);

        // Wait for the delay and then enable and show the button
        Invoke("EnableButton", delay);
    }

    private void EnableButton()
    {
        buttonToEnable.interactable = true;
        buttonToEnable.gameObject.SetActive(true);
    }
}