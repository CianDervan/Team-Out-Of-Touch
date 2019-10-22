using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrabbingScript : MonoBehaviour//,IPointerClickHandler
{
   
    public GameObject GrabbableObject;

    private ConstantForce ArmForce;

    public Rigidbody CharacterArm;

    private bool WantsToGrab = false;

    //public float ArmForce;
    
  // public void  SetLookRotation(Vector3 view, Vector3 up = Vector3.up); 
  
  //public static Quaternion LookRotation(Vector3 forward, Vector3 upwards = Vector3.up); 
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ArmForce = GetComponent<ConstantForce>();
        
        //Camera.main.transform.rotation = Quaternion.LookRotation
        //(transform.position + Vector3.up * 7f - Camera.main.transform.position, Vector3.up);

        // transform the world forward into local space:
        //Vector3 relative;
       // relative = transform.InverseTransformDirection(Vector3.forward);
        //relative = transform.TransformDirection(Vector3.forward);
        //this.transform.forward = relative;
        //Debug.Log(relative);
        // Hand = GrabbableObject.gameObject.AddComponent<FixedJoint>();
        //Hand
    }
    
    public Transform target;
    public Transform armTarget;
    Vector3 lookDirection;
    public float speed;
    public float epsilon;
    /*void Update()
    {
        //Vector3 relativePos = target.position - transform.position;
       // transform.LookAt (armTarget.position);
        // the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        //transform.rotation = rotation;
    }*/

    public float thrust;
    public Rigidbody rb;
    public Rigidbody directionRb;
    public float RotateSpeed = 30f;

    public void Grab()
    {
        WantsToGrab = !WantsToGrab;
       
    //rb.AddRelativeForce(Vector3.forward * thrust);
        //rb.AddForce(Vector3.forward * thrust);
        //rb.velocity = directionRb.transform.forward * thrust * Time.deltaTime;
        
        //ArmForce.enabled = !ArmForce.enabled;
        
        
        //float step =  speed * Time.deltaTime; // calculate distance to move
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        //transform.LookAt (armTarget.position);
        
       // lookDirection = (armTarget.position - transform.position).normalized;
        //lookDirection = (aTarget.position - transform.position);

        //if (( transform.position - armTarget.position).magnitude > epsilon)

       // {
        //    transform.Translate (lookDirection * Time.deltaTime * speed);
            //transform.Translate (0.0f, 0.0f, speed * Time.deltaTime);
        //}
        
    }
    

    void OnTriggerEnter(Collider other)
    {
        if(WantsToGrab == true)
        {

        }
    }
}
