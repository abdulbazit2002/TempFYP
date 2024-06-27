using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        string levelReached = PlayerPrefs.GetString("LevelReached", "1.1");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            string levelName = GetLevelName(i + 1);
            if (string.Compare(levelName, levelReached) > 0)
            {
                levelButtons[i].interactable = false;
                // Add lock image or disable button here
                levelButtons[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                levelButtons[i].interactable = true;
                // Remove lock image here
                levelButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                // Add listener to load the appropriate level
                int index = i + 1;
                if (index == 1)
                {
                    levelButtons[i].onClick.AddListener(() => SelectLevel(levelName));
                }
                else
                {
                    int buttonIndex = index;
                    levelButtons[i].onClick.AddListener(() => ShowLockedMessage(buttonIndex));
                }
            }
        }
    }

    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LevelCleared(string levelName)
    {
        string levelReached = PlayerPrefs.GetString("LevelReached", "1.1");
        if (string.Compare(levelName, levelReached) >= 0)
        {
            PlayerPrefs.SetString("LevelReached", GetNextLevelName(levelName));
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowReward()
    {
        Debug.Log("Show Reward");
        // SceneManager.LoadScene("RewardScene");
    }

    private void ShowLockedMessage(int buttonIndex)
    {
        Debug.Log("Button " + buttonIndex + " is locked.");
    }

    private string GetLevelName(int buttonIndex)
    {
        // Map the button index to the level name
        if (buttonIndex >= 1 && buttonIndex <= 3)
            return "1." + buttonIndex;
        else if (buttonIndex >= 4 && buttonIndex <= 6)
            return "2." + (buttonIndex - 3);
        else if (buttonIndex >= 7 && buttonIndex <= 10)
            return "3." + (buttonIndex - 6);
        else if (buttonIndex >= 11 && buttonIndex <= 13)
            return "4." + (buttonIndex - 10);
        else if (buttonIndex == 14)
            return "5.1";
        else
            return "1.1"; // Default level if index is out of range
    }

    private string GetNextLevelName(string currentLevelName)
    {
        // Determine the next level based on the current level name
        if (currentLevelName == "5.1")
            return "5.1"; // Last level, stays the same

        string[] parts = currentLevelName.Split('.');
        int mainLevel = int.Parse(parts[0]);
        int subLevel = int.Parse(parts[1]);

        if ((mainLevel == 1 && subLevel < 3) ||
            (mainLevel == 2 && subLevel < 3) ||
            (mainLevel == 3 && subLevel < 4) ||
            (mainLevel == 4 && subLevel < 3))
        {
            return mainLevel + "." + (subLevel + 1);
        }
        else
        {
            return (mainLevel + 1) + ".1";
        }
    }
}
