using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public Text storyText;
    public TMP_Text storyTMPText; // For TextMeshPro support
    public Button nextButton;
    [SerializeField] private typewriterUI_v2 typewriter;
    [SerializeField] private string nextSceneName;  // Name of the next scene to load

    private string[] storyParts = {
        "Once upon a time, in a land far, far away...",
        "There lived a brave knight who fought dragons.",
        "One day, he embarked on a quest to find a magical sword.",
        "After many adventures, he found the sword and saved the kingdom.",
        "The End."
    };
    private int currentPartIndex = 0;

    void Start()
    {
        nextButton.gameObject.SetActive(false);
        typewriter.OnTextComplete += OnTextComplete;
        DisplayNextPart();
        nextButton.onClick.AddListener(NextButtonClicked);
    }

    void DisplayNextPart()
    {
        if (currentPartIndex < storyParts.Length)
        {
            if (storyText != null)
            {
                storyText.text = storyParts[currentPartIndex];
            }
            if (storyTMPText != null)
            {
                storyTMPText.text = storyParts[currentPartIndex];
            }

            typewriter.StartTypewriter();
        }
        else
        {
            // All parts of the story have been shown, load the next scene
            LoadNextScene();
        }
    }

    void OnTextComplete()
    {
        nextButton.gameObject.SetActive(true);
    }

    void NextButtonClicked()
    {
        currentPartIndex++;
        nextButton.gameObject.SetActive(false);
        DisplayNextPart();
    }

    void LoadNextScene()
    {
        // Load the specified next scene
        SceneManager.LoadScene(nextSceneName);
    }
}