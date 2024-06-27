using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFailedPanel : MonoBehaviour
{
    public Button homeButton; // Reference to the home button
    public Button retryButton; // Reference to the retry button

    void Start()
    {
        homeButton.onClick.AddListener(GoToMainMenu);
        retryButton.onClick.AddListener(RetryCurrentLevel);
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
