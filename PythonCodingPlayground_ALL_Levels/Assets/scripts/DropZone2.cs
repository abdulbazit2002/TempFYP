using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone2 : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //public Animator animator; // Drag and drop the object with the Animator component onto this field in the Inspector

    private Draggable currentDraggable;
    private bool dance1 = false;
    private bool isOccupied = false; // Flag to indicate if the drop zone is occupied

  

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

            // Check if the dragged object has the "Dance1" tag
            if (d.gameObject.tag == "Dance1")
            {
                // Set the Dance1 parameter to true
                dance1 = true;
            }
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

            // Set the Dance1 parameter to false
            dance1 = false;

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

            // Check if the dropped object has the "Dance1" tag
            if (d.gameObject.tag == "Dance1")
            {
                // Set the Dance1 parameter to true
                dance1 = true;
            }

            // Set the isOccupied flag to true
            isOccupied = true;
        }
    }
}