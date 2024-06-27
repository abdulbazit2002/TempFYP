using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DropZoneLevel5 : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator; // Drag and drop the object with the Animator component onto this field in the Inspector

    private Draggable currentDraggable;
    private List<string> animationSequence = new List<string>(); // List to store the animation sequence
    private bool isOccupied = false; // Flag to indicate if the drop zone is occupied

    private void Update()
    {
        // Check if there are any dropped objects in the drop zone
        Draggable[] droppedObjects = GetComponentsInChildren<Draggable>();
        foreach (Draggable d in droppedObjects)
        {
            if (d.parentToReturnTo == this.transform)
            {
                // Add the animation to the sequence
                if (d.gameObject.tag == "Dance1")
                {
                    animationSequence.Add("Dance");
                }
                else if (d.gameObject.tag == "wave")
                {
                    animationSequence.Add("wave");
                }
                else if (d.gameObject.tag == "punch")
                {
                    animationSequence.Add("punching");
                }
                else if (d.gameObject.tag == "flip")
                {
                    animationSequence.Add("backflip");
                }
            }
        }

        // Play the animation sequence
        if (animationSequence.Count > 0)
        {
            string currentAnimation = animationSequence[0];
            animator.Play(currentAnimation);
            animationSequence.RemoveAt(0);
        }
        else
        {
            // Stop the animation
            animator.StopPlayback();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (isOccupied)
            {
                // If the drop zone is already occupied, don't allow the new object to enter
                return;
            }

            d.placeHolderParent = this.transform;
            currentDraggable = d;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d == currentDraggable)
        {
            d.placeHolderParent = d.parentToReturnTo;
            currentDraggable = null;

            // Set the isOccupied flag to false
            isOccupied = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (isOccupied)
            {
                // If the drop zone is already occupied, don't allow the new object to be dropped
                return;
            }

            d.parentToReturnTo = this.transform;

            // Set the isOccupied flag to true
            isOccupied = true;
        }
    }
}