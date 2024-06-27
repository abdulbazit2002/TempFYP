using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class panels : MonoBehaviour
{
    public GameObject panel; // Assign the panel in the inspector
    public Button deactivateButton; // Assign the deactivate button in the inspector
    public Button retryButton; // Assign the retry button in the inspector
    public Button mainMenuButton; // Assign the main menu button in the inspector

    void Start()
    {
        // Check if all UI elements are assigned
        if (panel == null)
        {
            Debug.LogError("Panel is not assigned in the Inspector");
        }

        if (deactivateButton == null)
        {
            Debug.LogError("DeactivateButton is not assigned in the Inspector");
        }

        if (retryButton == null)
        {
            Debug.LogError("RetryButton is not assigned in the Inspector");
        }

        if (mainMenuButton == null)
        {
            Debug.LogError("MainMenuButton is not assigned in the Inspector");
        }

        // Remove any existing listeners to avoid duplicate calls
        if (deactivateButton != null)
        {
            deactivateButton.onClick.RemoveAllListeners();
            deactivateButton.onClick.AddListener(DeactivatePanel);
        }

        if (retryButton != null)
        {
            retryButton.onClick.RemoveAllListeners();
            retryButton.onClick.AddListener(RetryLevel);
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        }
    }

    void DeactivatePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    void RetryLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Main Menu"); // Replace "MainMenu" with the name of your main menu scene
    }
}
