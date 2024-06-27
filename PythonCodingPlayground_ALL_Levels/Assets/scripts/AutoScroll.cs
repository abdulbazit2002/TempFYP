using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoScroll : MonoBehaviour
{
    float speed = 300.0f;
    float textPosBegin = -833.0f;
    float boundaryTextEnd = 673.0f;

    RectTransform myGorectTransform;
    [SerializeField] 
    TextMeshProUGUI mainText;

    [SerializeField] 
    bool isLooping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }
    IEnumerator AutoScrollText()
    {
        // Calculate the boundaries of the UI box
        float minY = textPosBegin;
        float maxY = boundaryTextEnd;

        while (true)
        {
            // Scroll the text upward
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);

            // Clamp the position of the text within the boundaries
            Vector3 clampedPosition = myGorectTransform.localPosition;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
            myGorectTransform.localPosition = clampedPosition;

            // Check if the text has reached the boundary
            if (myGorectTransform.localPosition.y >= maxY)
            {
                // If looping is enabled, reset the position of the text to the beginning
                if (isLooping)
                {
                    myGorectTransform.localPosition = new Vector3(myGorectTransform.localPosition.x, minY, myGorectTransform.localPosition.z);
                }
                else
                {
                    // If looping is disabled, break out of the loop
                    break;
                }
            }

            yield return null;
        }
    }
}