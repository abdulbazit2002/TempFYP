using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void CompleteLevel()
    {
        // Get the current active scene's name and pass it to LevelCleared
        FindObjectOfType<LevelManager>().LevelCleared(SceneManager.GetActiveScene().name);

        // Load the level selection screen
        SceneManager.LoadScene("LevelSelectionScene"); // Replace with your level selection scene name
    }
}
