using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject settingsPanel;
    public GameObject AboutPanel;

    public void PlayGame()
    {
        // Load the level selection scene (assuming the build index is 1)
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        // Activate the credits panel
        creditsPanel.SetActive(true);
        settingsPanel.SetActive(false);// Ensure the settings panel is deactivated
        AboutPanel.SetActive(false);        // Ensure the settings panel is deactivated 
    }

    public void ShowSettings()
    {
        // Activate the settings panel
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false); // Ensure the credits panel is deactivated
        AboutPanel.SetActive(false);       // Ensure the settings panel is deactivated 
    }
    public void ShowAbout()
    {
        // Activate the settings panel
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false); // Ensure the credits panel is deactivated
        AboutPanel.SetActive(true);        // Ensure the settings panel is deactivated 
    }

    public void HidePanels()
    {
        // Deactivate both panels
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        AboutPanel.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
