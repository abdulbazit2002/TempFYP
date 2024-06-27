// Script for GameObject 2
using UnityEngine;

public class PlayAnimation2 : MonoBehaviour
{
    public Animation animationComponent;

    private void Start()
    {
        // Disable the Animation component initially
        animationComponent.enabled = false;

        // Subscribe to the event triggered by the completion of the first animation
        PlayAnimation1.OnAnimation1Complete += OnAnimation1Complete;
    }

    private void OnAnimation1Complete()
    {
        // Enable and play the Animation component when the first animation completes
        animationComponent.enabled = true;
        animationComponent.Play();
    }
}
