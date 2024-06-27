using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class FinalLevelManager : MonoBehaviour
{
    public AutoDropZone3_1 intJar; // Reference to the script attached to the integer jar game object
    public AutoDropZone3_3 stringJar; // Reference to the script attached to the string jar game object
    public AutoDropZone3_2 boolJar; // Reference to the script attached to the boolean jar game object
    public GameObject winPanel; // Reference to the win panel

    void Update()
    {
        // Check if all correct placements are achieved for each jar
        bool allPlacementsCorrect = intJar.correctPlacements == intJar.totalCorrectPlacementsNeeded &&
                                    stringJar.correctPlacements == stringJar.totalCorrectPlacementsNeeded &&
                                    boolJar.correctPlacements == boolJar.totalCorrectPlacementsNeeded;

        // If all correct placements are achieved, activate win panel
        if (allPlacementsCorrect)
        {
            Debug.Log("All correct placements achieved. Activating win panel...");
            StartCoroutine(ActivateWinPanelAfterDelay(5f)); // Activate win panel after a delay of 5 seconds
        }
    }

    IEnumerator ActivateWinPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        winPanel.SetActive(true);
    }
}
