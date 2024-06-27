using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    public Button nextLevelButton;
    public Button homeButton;
    public Button retryButton;
    public string nextLevelName; // Public variable to set the next level's name in the Inspector

    void Start()
    {
        nextLevelButton.onClick.AddListener(LoadNextLevel);
        homeButton.onClick.AddListener(GoToMainMenu);
        retryButton.onClick.AddListener(RetryCurrentLevel);
    }

    public void LoadNextLevel()
    {
        // Check if the nextLevelName is not empty or null
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            // Load the next level scene
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.LogWarning("Next level name is not set. Please set it in the Inspector.");
        }
    }

    void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Main Menu"); // Replace with your main menu scene name
    }

    void RetryCurrentLevel()
    {
        // Reload the current level scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
