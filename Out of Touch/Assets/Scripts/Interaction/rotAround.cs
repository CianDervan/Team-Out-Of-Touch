using System;
using UnityEngine;
using System.Collections;
using System.Security;

public class rotAround : MonoBehaviour
{
    private Rigidbody myRotRb;
    
    public float rotx;
    public float roty;
    public float rotz;

   // public Vector3 idealRotation;
   // public Vector3 currentRotation;
    //public Vector3 torqueForce;
    
    //public Vector3 velocity;
   // public Quaternion actualRotation;
    
    public float factor = .1f;

    private void Start()
    {
        //myRotRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () 
    {
        //transform.Rotate (new Vector3 (rotx, roty, rotz) * Time.deltaTime);
       // myRotRb.AddTorque(rotx, roty, rotz);
        transform.Rotate(rotx, roty, rotz);
      //  actualRotation = myRotRb.rotation;
       // currentRotation = myRotRb.angularVelocity;
       // velocity = myRotRb.velocity;
        //torqueForce = (idealRotation - currentRotation) * factor; 
        //myRotRb.AddTorque(torqueForce);

    }
}
        