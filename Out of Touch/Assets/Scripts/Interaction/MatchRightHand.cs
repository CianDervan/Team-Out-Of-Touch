using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchRightHand : MonoBehaviour
{
    public KnowGrab rightHandGrabManager;

    private Rigidbody myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightHandGrabManager.carrying)
        {
            FixedJoint grabJoint = rightHandGrabManager.objectToGrab.AddComponent<FixedJoint>();
            
            grabJoint.connectedBody = myRb;
            grabJoint.breakForce = Single.PositiveInfinity;
            grabJoint.enablePreprocessing = false;
        }

        
    }
}
