using UnityEngine;

public class PanelDeactivator : MonoBehaviour
{
    public GameObject panelToDeactivate; // Reference to the panel to deactivate

    // Method to deactivate the panel
    public void DeactivatePanel()
    {
        if (panelToDeactivate != null)
        {
            panelToDeactivate.SetActive(false);
        }
    }
}
