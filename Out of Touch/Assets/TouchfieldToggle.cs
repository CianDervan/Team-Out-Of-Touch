using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchfieldToggle : MonoBehaviour
{
    private bool tfOn = true;
    public GameObject tfImage;

    public void turnTFon()
    {
        tfImage.SetActive(true);
        tfOn = true;
    }
    
    public void turnTFoff()
    {
        tfImage.SetActive(false);
        tfOn = false;
    }
    
    public void DoToggle()
    {
        if (tfOn)                        
        {
            turnTFoff();
        }

        else if (!tfOn)
        {
            turnTFon();
        }
    }
}
