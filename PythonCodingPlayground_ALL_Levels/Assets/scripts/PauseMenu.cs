using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button backButton;
    public Button homeButton;
    public Button retryButton;
    public Button musicButton;
    public Button soundButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isMusicOn = true;
    private bool isSoundOn = true;

    private List<GameObject> panels; // List to store other panels
    private List<GameObject> previouslyActivePanels; // List to store previously active panels

    void Start()
    {
        backButton.onClick.AddListener(BackToGame);
        homeButton.onClick.AddListener(GoToMainMenu);
        retryButton.onClick.AddListener(RetryLevel);
        musicButton.onClick.AddListener(ToggleMusic);
        soundButton.onClick.AddListener(ToggleSound);

        pauseMenuUI.SetActive(false);

        // Find all panels in the scene (assuming they all have the tag "Panel")
        panels = new List<GameObject>(GameObject.FindGameObjectsWithTag("Panel"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // Store and deactivate all currently active panels
        previouslyActivePanels = panels.FindAll(panel => panel.activeSelf);
        foreach (GameObject panel in previouslyActivePanels)
        {
            panel.SetActive(false);
        }

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void Resume()
    {
        // Reactivate previously active panels
        foreach (GameObject panel in previouslyActivePanels)
        {
            panel.SetActive(true);
        }

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    void BackToGame()
    {
        Resume();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game isn't paused
        SceneManager.LoadScene("Main Menu"); // Replace with your main menu scene name
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f; // Ensure the game isn't paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }

    void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        if (isMusicOn)
        {
            // Logic to turn on music
            musicButton.image.sprite = musicOnSprite;
        }
        else
        {
            // Logic to turn off music
            musicButton.image.sprite = musicOffSprite;
        }
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        if (isSoundOn)
        {
            // Logic to turn on sound
            soundButton.image.sprite = soundOnSprite;
        }
        else
        {
            // Logic to turn off sound
            soundButton.image.sprite = soundOffSprite;
        }
    }
}
