using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public GameObject currentHitObject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    public Vector3 origin;
    public Vector3 direction;

    public float currentHitDistance;

    public SphereCollider mySphereCollider;
    
    public Rigidbody hips;
    public Rigidbody facePlant;
    public Rigidbody COMConnector;
    public ConstantForce[] uprightforces;
    
    
    
    /* private bool GroundCheck(float groundCheckHeight, out bool result)
 {

     Physics.SphereCast(this.transform.position +
                        // here, to make the sphere start position higher by this offset
                        Vector3.up * (mySphereCollider. radius + Physics.defaultContactOffset),
         // and here to make the sphere radius lower by this offset
         mySphereCollider.radius - Physics.defaultContactOffset,
         Vector3.down, out groundHitInfo, maxCheckHeight);
     
     Debug.Log ("Dist: " + groundHitInfo.distance + ", collider: " + groundHitInfo.collider);
     return result =
         groundHitInfo.distance <= groundCheckHeight
             ? true : false;

 }*/

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -30F, 0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        origin = transform.position;
        direction = transform.up * -1;
        RaycastHit hit;
        //if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        
        if (Physics.SphereCast(origin + Vector3.up * (mySphereCollider. radius + Physics.defaultContactOffset),
                        mySphereCollider.radius - Physics.defaultContactOffset, direction, out hit, maxDistance, layerMask, 
                               QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            
            //hips.GetComponent<ConstantForce>().force = new Vector3(0, -250, 0);
            facePlant.GetComponent<Rigidbody>().mass = 1;
           
            uprightforces[0].enabled = true; // com
            uprightforces[1].enabled = true; // head
            uprightforces[2].enabled = true; // torso
            uprightforces[3].enabled = true; // hips
            Physics.gravity = new Vector3(0, -30F, 0);
            hips.GetComponent<SpringJoint>().connectedBody = COMConnector;
            //COMConnector.GetComponent<FixedJoint>().connectedBody = hips;
 
        }

        else
        {
            currentHitObject = null;
            currentHitDistance = maxDistance;
            
            //hips.GetComponent<ConstantForce>().force = new Vector3(0, -1000, 0);
            facePlant.GetComponent<Rigidbody>().mass = 10;
            
            uprightforces[0].enabled = false; // com
            uprightforces[1].enabled = false; // head
            uprightforces[2].enabled = false; // torso
            uprightforces[3].enabled = false; // hips
            Physics.gravity = new Vector3(0, -750F, 0);
            hips.GetComponent<SpringJoint>().connectedBody = null;
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
