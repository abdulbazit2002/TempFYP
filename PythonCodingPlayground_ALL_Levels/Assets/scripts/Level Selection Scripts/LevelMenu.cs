using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    private int totalMainLevels = 5; // Total number of main levels

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Calculate the total number of levels
        int totalLevels = totalMainLevels * 3; // Assuming 3 sublevels for each main level

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int level)
    {
        int subLevel = 1;
        int mainLevel = 1;

        // Calculate main and sublevel based on button index
        if (level <= 3)
        {
            mainLevel = 1;
            subLevel = level;
        }
        else if (level <= 6)
        {
            mainLevel = 2;
            subLevel = level - 3;
        }
        else if (level <= 10)
        {
            mainLevel = 3;
            subLevel = level - 6;
        }
        else if (level <= 13)
        {
            mainLevel = 4;
            subLevel = level - 10;
        }
        else if (level == 14)
        {
            mainLevel = 5;
            subLevel = 1;
        }

        string levelName = "Level " + mainLevel + "-" + subLevel;
        SceneManager.LoadScene(levelName);
    }


    public void ReturnToLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu"); // Change "LevelMenu" to your actual level menu scene name
    }
}
