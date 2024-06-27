using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public GameObject winPanel;  // Reference to the win panel

    // Method to activate the win panel
    private void ActivateWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }

    // Method to be called when the button is pressed
    public void OnButtonClick()
    {
        ActivateWinPanel();
    }
}
