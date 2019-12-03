using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSCaster : MonoBehaviour
{
    public GameObject currentHitObject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public Vector3 origin;
    public Vector3 direction;

    public float currentHitDistance;

    //public SphereCollider mySphereCollider;
    public CapsuleCollider myCapsuleCollider;
    
    public Rigidbody hips;
    public Rigidbody facePlant;
   // public Rigidbody COMConnector;
   // public ConstantForce[] uprightforces;
    
    public Vector3 jump;
    public float jumpForce = 800.0f;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -30F, 0);
    }

    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    public void JumpJump()
    {
            facePlant.GetComponent<Rigidbody>().mass = 1;
            hips.AddForce(jump * jumpForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        origin = transform.position;
        direction = transform.up * -1;
        RaycastHit hit;
        //if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        
        if (Physics.SphereCast(origin + Vector3.up * (myCapsuleCollider. radius + Physics.defaultContactOffset),
                        myCapsuleCollider.radius - Physics.defaultContactOffset, direction, out hit, maxDistance, layerMask, 
                               QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            
           // hips.GetComponent<ConstantForce>().force = new Vector3(0, -250, 0);
            facePlant.GetComponent<Rigidbody>().mass = 1;
           
           // uprightforces[0].enabled = true; // com
            //uprightforces[0] == 
          //  uprightforces[1].enabled = true; // head
          //  uprightforces[2].enabled = true; // torso
          //  uprightforces[3].enabled = true; // hips
            Physics.gravity = new Vector3(0, -30F, 0);
           // hips.GetComponent<SpringJoint>().connectedBody = COMConnector;
            //COMConnector.GetComponent<FixedJoint>().connectedBody = hips;
            
           // if (hit.transform.gameObject.CompareTag("lift"))
           // {
              //  transform.parent = hit.transform.parent;
           // }
           hips.GetComponent<CapsuleCollider>().enabled = true;

        }

        else
        {
            currentHitObject = null;
            currentHitDistance = maxDistance;
            
            //hips.GetComponent<ConstantForce>().force = new Vector3(0, -1000, 0);
           facePlant.GetComponent<Rigidbody>().mass = 10;
            //facePlant.mass = 10;
            hips.GetComponent<CapsuleCollider>().enabled = false;
            
           // uprightforces[0].enabled = false; // com
           // uprightforces[1].enabled = false; // head
           // uprightforces[2].enabled = false; // torso
          //  uprightforces[3].enabled = false; // hips
            Physics.gravity = new Vector3(0, -750F, 0);
           // hips.GetComponent<SpringJoint>().connectedBody = null;
            //COMConnector.GetComponent<FixedJoint>().connectedBody = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
