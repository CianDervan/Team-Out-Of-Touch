using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {
 
    //public float movementSpeed;
    //public float rotationSpeed;
    public float rotX;
    public float rotY;
    public float rotZ;

    bool isSpinning = false;
    bool nowIwantToSpin = false;
    public Button spinButton;

    private void Start()
    {
        spinButton.onClick.AddListener(DoToggle);
    }

    public void makeMeSpinNow()
    {
        //nowIwantToSpin = true;
        nowIwantToSpin = !nowIwantToSpin;
    }
    
    public void makeMeStopNow()
    {
        nowIwantToSpin = false;
    }

    private void Update()
    {
        if (nowIwantToSpin)
        {
            spinMe();
            //isSpinning = true;
        }
        
        if (!nowIwantToSpin)
        {
            spinMeNot();
            //isSpinning = true;
        }
    }

    public void DoToggle()
    {
        if (!isSpinning)
        {
            spinMe();
            isSpinning = true;
        }
        
        else if (isSpinning)
        {
            spinMeNot();
            isSpinning = false;
        }
        
    }
    
    public void spinMe()
    {

        transform.Rotate(rotX, rotY, rotZ);// * GetComponent<Rigidbody>().velocity;
        
    }
    
    public void spinMeNot()
    {

        transform.Rotate(0, 0, 0);
        
    }
}
