using UnityEngine;

public class ActivateAndDisablePanel : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject
    public float delayBeforeActivate = 0f; // Delay before activating the panel in seconds
    public float delayBeforeDisable = 10f; // Delay before disabling the panel in seconds

    private void Start()
    {
        // Deactivate the panel when the scene starts
        panel.SetActive(false);

        // Activate the panel after the delay
        Invoke("ActivatePanel", delayBeforeActivate);

        // Disable the panel after another delay
        Invoke("DisablePanel", delayBeforeActivate + delayBeforeDisable);
    }

    private void ActivatePanel()
    {
        // Activate the panel after the delay
        panel.SetActive(true);
    }

    private void DisablePanel()
    {
        // Deactivate the panel after the delay
        panel.SetActive(false);
    }
}
