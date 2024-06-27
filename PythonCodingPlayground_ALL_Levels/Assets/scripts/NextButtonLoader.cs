using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonLoader : MonoBehaviour
{// This method will be called when the button is pressed
    public void LoadNextScene()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Calculate the next scene's index
        int nextSceneIndex = currentScene.buildIndex + 1;

        // Check if the next scene index is within the range of scenes in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load. This is the last scene.");
        }
    }
}
