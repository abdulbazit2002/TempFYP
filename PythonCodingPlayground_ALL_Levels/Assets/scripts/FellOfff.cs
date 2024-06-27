using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellOfff : MonoBehaviour
{

    public GameObject fail;
    public GameObject buttonsContainer;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Char")
        {
            buttonsContainer.SetActive(false);
            fail.SetActive(true);
        }

    }
}
