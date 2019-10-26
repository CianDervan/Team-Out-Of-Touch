using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactForce : MonoBehaviour
{
    public Rigidbody myRb;
    
    /*public void hyperPushBack() { 
        // revert player velocity:
        myRb.velocity *= -1;
    }*/
    
    private void OnCollisionEnter (Collision collision) {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;
        Vector3 hyperPushBack = myRb.velocity *= -1 * collisionForce;
        myRb.AddForce(hyperPushBack);
       // myRb.AddForce(new Vector3(rightDirection.x, 0, rightDirection.z) * veloRate);
       
    }
}
