using UnityEngine;
using UnityEngine.UI;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel; // Assign the panel in the inspector
    public Button activateButton; // Assign the button in the inspector

    void Start()
    {
        // Ensure the panel is inactive at the start
        panel.SetActive(false);

        // Remove any existing listeners to avoid duplicate calls
        activateButton.onClick.RemoveAllListeners();

        // Add a listener to the button to call the ActivatePanel method when clicked
        activateButton.onClick.AddListener(ActivatePanel);
    }

    void ActivatePanel()
    {
        panel.SetActive(true);
    }
}
