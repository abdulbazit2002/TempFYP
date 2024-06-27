using UnityEngine;

public class PlayAnimationAndDisable2 : MonoBehaviour
{
    public Animation animationComponent; // Reference to the Animation component
    public float animationDuration = 10f; // Duration of the animation in seconds

    private void Start()
    {
        // Check if an Animation component is attached
        if (animationComponent == null)
        {
            Debug.LogWarning("Animation component reference is not set.");
            return;
        }

        // Play the animation
        animationComponent.Play();

        // Disable the GameObject after the animation duration
        Invoke("DisableGameObject", animationDuration);
    }

    private void DisableGameObject()
    {
        gameObject.SetActive(false); // Disable the GameObject
    }
}
