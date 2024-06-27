using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    public GameObject panel; // Assign the Panel game object in the Inspector

    public void OnButtonClick()
    {
        panel.SetActive(true); // Turn on the panel when the button is clicked
    }
}