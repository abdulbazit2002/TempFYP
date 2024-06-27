// Script for GameObject 1
using UnityEngine;

public class PlayAnimation1 : MonoBehaviour
{
    public delegate void Animation1CompleteAction();
    public static event Animation1CompleteAction OnAnimation1Complete;

    public Animation animationComponent;

    private void Start()
    {
        animationComponent.Play();
        Invoke(nameof(TriggerAnimation1CompleteEvent), animationComponent.clip.length);
    }

    private void TriggerAnimation1CompleteEvent()
    {
        OnAnimation1Complete?.Invoke();
    }
}
