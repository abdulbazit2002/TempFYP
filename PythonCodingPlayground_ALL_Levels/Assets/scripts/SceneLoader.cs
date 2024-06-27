using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Method to load scene based on the scene name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
