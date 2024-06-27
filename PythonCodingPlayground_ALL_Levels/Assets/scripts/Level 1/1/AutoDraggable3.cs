using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class AutoDraggable3 : MonoBehaviour, IDropHandler
{
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public float correctColorDuration = 2f;
    public float incorrectColorDuration = 2f;
    public Transform letterBox; // Reference to the letter box transform
    public MainBox mainBox; // Reference to the MainBox script
    public GameObject winPanel; // Reference to the win panel
    public AudioClip correctSoundClip; // Reference to the AudioClip for correct sound
    public AudioClip incorrectSoundClip; // Reference to the AudioClip for incorrect sound

    private AudioSource audioSource;
    private string[] correctTagOrder = { "Q1", ")" }; // Update with the actual tags
    private int currentIndex = 0;
    private GridLayoutGroup gridLayout;

    private void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        audioSource = gameObject.AddComponent<AudioSource>();
        if (winPanel != null)
        {
            winPanel.SetActive(false); // Ensure win panel is initially inactive
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        AutoDraggable draggable = eventData.pointerDrag.GetComponent<AutoDraggable>();
        if (draggable != null && !draggable.IsLocked)
        {
            draggable.parentToReturnTo = transform;

            // Check if the dropped object has the correct tag
            if (CheckCorrectness(draggable.gameObject))
            {
                draggable.IsCorrect = true;
                draggable.IsLocked = true;
                SetColor(draggable.gameObject, correctColor);
                StartCoroutine(LockCorrectObject(draggable));

                // If correct tag is dropped, use grid layout group
                draggable.GetComponent<RectTransform>().SetParent(transform);

                // Play correct sound
                if (correctSoundClip != null)
                {
                    PlaySound(correctSoundClip);
                }

                // Notify MainBox that an object is placed correctly
                mainBox.ObjectPlaced();

                // Check if all tags are matched correctly
                if (currentIndex >= correctTagOrder.Length)
                {
                    Debug.Log("All tags matched correctly.");
                    StartCoroutine(ActivateWinPanelAfterDelay());
                }
            }
            else
            {
                // Highlight the dropped object indicating it's incorrect
                SetColor(draggable.gameObject, incorrectColor);
                StartCoroutine(ReturnIncorrectObject(draggable));

                // Play incorrect sound
                if (incorrectSoundClip != null)
                {
                    PlaySound(incorrectSoundClip);
                }
            }

            // Rebuild layout to reposition elements correctly
            StartCoroutine(RebuildLayout());
        }
    }

    private bool CheckCorrectness(GameObject droppedObject)
    {
        if (currentIndex < correctTagOrder.Length && droppedObject.CompareTag(correctTagOrder[currentIndex]))
        {
            currentIndex++;
            return true;
        }
        else
        {
            Debug.Log("Tag does not match or incorrect sequence.");
            return false;
        }
    }

    private IEnumerator LockCorrectObject(AutoDraggable draggable)
    {
        yield return new WaitForSeconds(correctColorDuration);
        if (draggable != null)
        {
            SetColor(draggable.gameObject, Color.white); // Reset color
        }
    }

    private IEnumerator ReturnIncorrectObject(AutoDraggable draggable)
    {
        yield return new WaitForSeconds(incorrectColorDuration);
        if (draggable != null)
        {
            SetColor(draggable.gameObject, Color.white); // Reset color
        }

        // Stop the incorrect sound if it's still playing
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (draggable == null)
        {
            yield break;
        }

        // Return the incorrect object to its original position or the letter box
        if (draggable.IsLocked)
        {
            // Object is correctly placed, return it to its original position
            draggable.ReturnToOriginalPosition();
        }
        else
        {
            // Object is incorrectly placed, respawn it in the letter box
            if (letterBox != null)
            {
                // Instantiate a new instance of the incorrect object
                GameObject newObject = Instantiate(draggable.gameObject, letterBox.position, Quaternion.identity, letterBox);

                // Ensure it's an AutoDraggable component
                AutoDraggable newDraggable = newObject.GetComponent<AutoDraggable>();
                if (newDraggable != null)
                {
                    newDraggable.ReturnToOriginalPosition(); // Return to original position in the letter box
                }
                else
                {
                    Debug.LogWarning("AutoDraggable component not found on respawned object.");
                }
            }
            else
            {
                Debug.LogWarning("Letter box reference is not set in AutoDropZone script.");
            }

            // Remove the original object from the drop zone
            Destroy(draggable.gameObject);
        }
    }

    private IEnumerator RebuildLayout()
    {
        // Wait for one frame for layout rebuild
        yield return null;

        // Rebuild layout
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
    }

    private void SetColor(GameObject obj, Color color)
    {
        Graphic graphic = obj.GetComponent<Graphic>();
        if (graphic != null)
        {
            graphic.color = color;
        }
    }

    private IEnumerator ActivateWinPanelAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            SoundManager.PlaySound("win");
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
    }
}
