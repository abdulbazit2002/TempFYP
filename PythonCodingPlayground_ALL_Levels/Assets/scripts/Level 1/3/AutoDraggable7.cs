using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class AutoDraggable7 : MonoBehaviour, IDropHandler
{
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public float correctColorDuration = 2f;
    public float incorrectColorDuration = 2f;
    public Transform letterBox; // Reference to the letter box transform
    public AudioClip correctSoundClip; // Reference to the AudioClip for correct sound
    public AudioClip incorrectSoundClip; // Reference to the AudioClip for incorrect sound

    private string[] correctTagOrder = { "Z", "=", "X", "+", "Y" };
    private int currentIndex = 0;
    private GridLayoutGroup gridLayout;
    private AudioSource audioSource;

    private void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        audioSource = gameObject.AddComponent<AudioSource>();
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

                // Check if all tags are matched correctly
                if (AllTagsMatched())
                {
                    Debug.Log("All tags matched correctly.");
                    // Implement win condition or other actions here
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
        }
    }

    private bool CheckCorrectness(GameObject droppedObject)
    {
        string correctTag = correctTagOrder[currentIndex];
        if (droppedObject.CompareTag(correctTag))
        {
            currentIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator LockCorrectObject(AutoDraggable draggable)
    {
        yield return new WaitForSeconds(correctColorDuration);
        SetColor(draggable.gameObject, Color.white); // Reset color
    }

    private IEnumerator ReturnIncorrectObject(AutoDraggable draggable)
    {
        yield return new WaitForSeconds(incorrectColorDuration);
        SetColor(draggable.gameObject, Color.white); // Reset color

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

    private void SetColor(GameObject obj, Color color)
    {
        Graphic graphic = obj.GetComponent<Graphic>();
        if (graphic != null)
        {
            graphic.color = color;
        }
    }

    private bool AllTagsMatched()
    {
        return currentIndex >= correctTagOrder.Length;
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
