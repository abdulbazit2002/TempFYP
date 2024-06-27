using UnityEngine;
using DG.Tweening;

public class HighlightAnimation : MonoBehaviour
{
    public float targetScale = 1.2f; // The scale to animate to
    public float duration = 0.5f;    // Duration of the animation

    private RectTransform rectTransform;
    private Vector2 initialSizeDelta;

    void Start()
    {
        // Get the RectTransform component
        rectTransform = GetComponent<RectTransform>();

        // Save the initial size of the RectTransform
        initialSizeDelta = rectTransform.sizeDelta;

        // Start the animation
        AnimateHighlight();
    }

    void AnimateHighlight()
    {
        // Calculate the target size
        Vector2 targetSizeDelta = initialSizeDelta * targetScale;

        // Scale up the RectTransform
        rectTransform.DOSizeDelta(targetSizeDelta, duration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            // Scale down the RectTransform back to its initial size
            rectTransform.DOSizeDelta(initialSizeDelta, duration).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                // Repeat the animation
                AnimateHighlight();
            });
        });
    }

    void OnDisable()
    {
        // Ensure to kill all tweens when the GameObject is disabled
        rectTransform.DOKill();
    }
}
