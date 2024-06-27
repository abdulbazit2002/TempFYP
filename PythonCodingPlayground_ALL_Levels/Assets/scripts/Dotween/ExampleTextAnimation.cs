using UnityEngine;
using DG.Tweening;

public class ExampleTextAnimation : MonoBehaviour
{
    // Public fields for setting positions manually in the Inspector
    public Vector2 offScreenPosition;  // Position where the text will be initially (off-screen)
    public Vector2 onScreenPosition;   // Position where the text will be displayed on screen

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Set the initial anchored position to off-screen
        rectTransform.anchoredPosition = offScreenPosition;

        // Move the text into the scene over 1 second
        rectTransform.DOAnchorPos(onScreenPosition, 1f)
                 .OnComplete(() =>
                 {
                     // Wait for 10 seconds, then move the text out of the scene
                     DOVirtual.DelayedCall(10f, () =>
                     {
                         rectTransform.DOAnchorPos(offScreenPosition, 1f);
                     });
                 });
    }
}
