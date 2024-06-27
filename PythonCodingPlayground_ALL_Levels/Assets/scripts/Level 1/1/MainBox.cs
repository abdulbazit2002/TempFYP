using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBox : MonoBehaviour
{
    public string[] dropZoneNames; // Array of drop zone names
    public string[] requiredTags;
    public float switchDelay = 5f; // Delay before activating win panel (changed to 5 seconds)
    public GameObject winPanel; // Reference to the win panel GameObject
    public GameObject[] otherPanels; // Reference to other panels to disable

    private void Start()
    {
        // Initial check for completion, if needed
        CheckCompletionAndActivateWinPanel();
    }

    private IEnumerator CheckCompletionAndActivateWinPanel()
    {
        yield return new WaitForSeconds(switchDelay); // Wait for the specified delay

        if (CheckCompletion())
        {
            Debug.Log("All boxes are complete. Activating win panel...");
            ActivateWinPanel();
        }
        else
        {
            Debug.Log("Some boxes are missing elements. Please check and try again.");
        }
    }

    private void ActivateWinPanel()
    {
        // Disable all other panels
        foreach (GameObject panel in otherPanels)
        {
            panel.SetActive(false);
        }
        // Activate the win panel
        winPanel.SetActive(true);
    }

    public void ObjectPlaced()
    {
        // Check if all boxes are complete every time an object is placed
        if (CheckCompletion())
        {
            // Start the coroutine to activate the win panel after the delay
            StartCoroutine(CheckCompletionAndActivateWinPanel());
        }
    }

    private bool CheckCompletion()
    {
        HashSet<string> allTags = new HashSet<string>(requiredTags);
        foreach (string dropZoneName in dropZoneNames)
        {
            GameObject dropZoneObject = GameObject.Find(dropZoneName);
            if (dropZoneObject != null)
            {
                // Check if the drop zone has AutoDraggable components
                AutoDraggable[] draggables = dropZoneObject.GetComponentsInChildren<AutoDraggable>();
                if (draggables != null && draggables.Length > 0)
                {
                    HashSet<string> droppedTags = new HashSet<string>();
                    foreach (AutoDraggable draggable in draggables)
                    {
                        droppedTags.Add(draggable.tag);
                    }
                    // Compare the dropped tags with the required tags
                    if (!droppedTags.SetEquals(allTags))
                    {
                        return false;
                    }
                }
                else
                {
                    // Log a warning if AutoDraggable components are not found in the drop zone
                    Debug.LogWarning("AutoDraggable components not found in drop zone: " + dropZoneName);
                    return false;
                }
            }
            else
            {
                // Log a warning if the drop zone GameObject is not found
                Debug.LogWarning("Drop zone not found: " + dropZoneName);
                return false;
            }
        }
        return true;
    }
}
