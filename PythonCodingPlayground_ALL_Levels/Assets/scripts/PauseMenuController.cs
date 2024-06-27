using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pausePanel; // Assign the pause panel in the inspector
    public Button pauseButton; // Assign the pause button in the inspector

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause panel is inactive at the start
        pausePanel.SetActive(false);

        // Remove all listeners first to prevent multiple listeners issue
        pauseButton.onClick.RemoveAllListeners();

        // Add listener to the pause button to call the TogglePause method when clicked
        pauseButton.onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivatePauseMenu();
        }
        else
        {
            DeactivatePauseMenu();
        }
    }

    void ActivatePauseMenu()
    {
        pausePanel.SetActive(true);
       // Time.timeScale = 0f; // Pause the game
    }

    void DeactivatePauseMenu()
    {
        pausePanel.SetActive(false);
        //Time.timeScale = 1f; // Resume the game
    }
}
