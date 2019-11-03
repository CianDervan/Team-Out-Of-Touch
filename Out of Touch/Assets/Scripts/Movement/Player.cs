using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerCollider m_playerCollider;

    public Rigidbody hips;
    public Rigidbody COMConnector;
    public ConstantForce[] uprightforces;
   // public float standForce = -300;
    void Start()
    {
        //...
        m_playerCollider = GetComponent<PlayerCollider>();
    }
    
    void LateUpdate()
    {
        if (PlayerCollider.Grounded)//(m_playerCollider.IsOnGround)
        { 
            hips.GetComponent<ConstantForce>().force = new Vector3(0, -300, 0);
           
           uprightforces[0].enabled = true; // com
           uprightforces[1].enabled = true; // head
           uprightforces[2].enabled = true; // torso
           uprightforces[3].enabled = true; // hips
           Physics.gravity = new Vector3(0, -25F, 0);
           hips.GetComponent<SpringJoint>().connectedBody = COMConnector;
           //COMConnector.GetComponent<FixedJoint>().connectedBody = hips;
        }
        else //if (! m_playerCollider.IsOnGround)
        {
            hips.GetComponent<ConstantForce>().force = new Vector3(0, -1000, 0);
            
            uprightforces[0].enabled = false; // com
            uprightforces[1].enabled = false; // head
            uprightforces[2].enabled = false; // torso
            uprightforces[3].enabled = false; // hips
            Physics.gravity = new Vector3(0, -500F, 0);
            hips.GetComponent<SpringJoint>().connectedBody = null;
           //COMConnector.GetComponent<FixedJoint>().connectedBody = null;
           
        }
    }
}

