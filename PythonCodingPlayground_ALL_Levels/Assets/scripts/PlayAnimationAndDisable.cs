using UnityEngine;

public class PlayAnimationAndDisable : MonoBehaviour
{
    public Animation animationComponent; // Reference to the Animation component
    public float delayBeforeAnimation = 10f; // Delay before playing the animation in seconds
    public float animationDuration = 15f; // Duration of the animation in seconds

    private void Start()
    {
        // Check if an Animation component is attached
        if (animationComponent == null)
        {
            Debug.LogWarning("Animation component reference is not set.");
            return;
        }

        // Delay the start of the animation
        Invoke("PlayAnimation", delayBeforeAnimation);
    }

    private void PlayAnimation()
    {
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
