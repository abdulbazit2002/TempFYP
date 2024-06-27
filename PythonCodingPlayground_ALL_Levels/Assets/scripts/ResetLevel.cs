using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        // Load the current scene, which will reset the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
