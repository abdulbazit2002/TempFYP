using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class JuicyButtonAnimation : MonoBehaviour
{
    public float targetScale = 1.2f; // The scale to animate to
    public float duration = 0.5f;    // Duration of the animation

    private RectTransform rectTransform;
    private Vector2 initialSizeDelta;
    private Vector3 initialScale;

    void Start()
    {
        // Get the RectTransform component
        rectTransform = GetComponent<RectTransform>();

        // Save the initial size and scale of the RectTransform
        initialSizeDelta = rectTransform.sizeDelta;
        initialScale = rectTransform.localScale;
    }

    // Triggered when the mouse hovers over the button
    public void OnPointerEnter()
    {
        // Animate the highlight effect
        AnimateHighlight(targetScale);
    }

    // Triggered when the mouse leaves the button
    public void OnPointerExit()
    {
        // Animate back to the initial state
        AnimateHighlight(1f);
    }

    void AnimateHighlight(float scale)
    {
        // Calculate the target size
        Vector2 targetSizeDelta = initialSizeDelta * scale;

        // Scale up/down the RectTransform
        rectTransform.DOSizeDelta(targetSizeDelta, duration).SetEase(Ease.InOutQuad);
        rectTransform.DOScale(initialScale * scale, duration).SetEase(Ease.InOutQuad);
    }

    // Renamed to avoid conflict
    void OnDisableAnimation()
    {
        // Ensure to kill all tweens when the GameObject is disabled
        rectTransform.DOKill();
    }
}
