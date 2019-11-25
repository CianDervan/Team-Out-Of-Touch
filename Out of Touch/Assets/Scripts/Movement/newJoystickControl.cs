using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newJoystickControl : MonoBehaviour
{/*
    public Joystick joystick;
    //public Joybutton joybutton;
    
   
    public float veloRate = 2500f;
    public float addForceRate = 25000;

    public FixedTouchField TouchField;
    
    public float CameraAngleX;
    public float CameraAngleSpeed = 0.2f;

    public Rigidbody myRb;
    //public Camera mCam;

    private Vector3 CamForward;
    private Transform mainCam;

    private Vector3 rightDirection;
    private Vector3 lookDirection;
    private Vector3 oldDirection;
    private Vector3 adjustment = new Vector3(0, 0, .0003f);
    private Vector3 stayStill = new Vector3(0, 0, 0);
    
    public float turnSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        //if (mainCam != null)
        //{
            mainCam = Camera.main.transform;
            myRb = GetComponent<Rigidbody>();
            joystick.DeadZone = 0.001f;
            myRb.velocity = stayStill;
            //joystick = FindObjectOfType<Joystick>();
            //joybutton = FindObjectOfType<Joybutton>();
            // }
    }

    void FixedUpdate()
    {
        // calculate camera relative direction
        CamForward = Vector3.Scale(mainCam.forward, new Vector3(1, 0, 1)).normalized;
        
        // creating variable for forward movement relative to camera direction
        rightDirection = joystick.Vertical * CamForward + joystick.Horizontal * mainCam.right;

                     // myRb.velocity = new Vector3(joystick.Horizontal * veloRate, myRb.velocity.y, joystick.Vertical * veloRate);
                    // make character face same direction as camera
                   // myRb.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up - Camera.main.transform.position, Vector3.up);
     
      // make character face same direction as joystick with smooth transition
      lookDirection = (new Vector3(rightDirection.x, 0, rightDirection.z));
      // determine method of rotation
      if ( rightDirection.x != 0 || rightDirection.y != 0) {
 
          // create a smooth direction to look at using Slerp()
          Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDirection, turnSpeed * Time.deltaTime);
          //Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDirection, turnSpeed * Time.deltaTime);
          
        // float turn = Input.GetAxis("Horizontal");
         //myRb.AddTorque(transform.up * turnSpeed * turn);
          
         // Vector3 smoothDir = Vector3.Slerp(transform.forward, rightDirection, turnSpeed * Time.deltaTime);
 
          transform.rotation = Quaternion.LookRotation (smoothDir);
          //myRb.AddTorque (Quaternion.LookRotation (smoothDir), ;
          // store the current smooth direction to use when the player is not providing input, otherwise snaps back to original rotation
          oldDirection = smoothDir;
          
          // slippery add force method
          //myRb.AddForce(new Vector3(rightDirection.x, 0, rightDirection.z) * (addForceRate * Time.deltaTime));
          
          //add arbitrary velocity method
          myRb.velocity = rightDirection * (veloRate * Time.deltaTime); 
        }
      else
      {

          transform.rotation = Quaternion.LookRotation(oldDirection + adjustment);
          
          // slippery add force method
          //myRb.AddForce(new Vector3(rightDirection.x, 0, rightDirection.z) * (addForceRate * Time.deltaTime));
          
          // add arbitrary velocity method
          myRb.velocity = rightDirection * (veloRate * Time.deltaTime); 
      }

      //camera swipe
      
      CameraAngleX += TouchField.TouchDist.x * CameraAngleSpeed;
      
      Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleX, Vector3.up) * new Vector3(0, 12, -30);
      Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 7f - Camera.main.transform.position, Vector3.up);
 
    }*/

    public GameObject LegRotationObject;
    public Joystick joystick;
    //public Joybutton joybutton;

    public Animator LegAnimator;

    public float veloRate = 2500f;
    public float addForceRate = 25000;

    public FixedTouchField TouchField;

    public float CameraAngleX;
    public float CameraAngleSpeed = 0.2f;

    public Rigidbody myRb;
    //public Camera mCam;

    private Vector3 CamForward;
    private Transform mainCam;

    private Vector3 rightDirection;
    private Vector3 lookDirection;
    private Vector3 oldDirection;
    private Vector3 adjustment = new Vector3(0, 0, .0003f);
    private Vector3 stayStill = new Vector3(0, 0, 0);

    public float turnSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        //if (mainCam != null)
        //{
        mainCam = Camera.main.transform;
        myRb = GetComponent<Rigidbody>();
        joystick.DeadZone = 0.001f;
        myRb.velocity = stayStill;
        //joystick = FindObjectOfType<Joystick>();
        //joybutton = FindObjectOfType<Joybutton>();
        // }

        LegRotationObject.SetActive(false);    
    }

    void FixedUpdate()
    {
        //Animator LegAnim = LegAnimator.GetComponent<Animator>();

        //bool StartWalk = LegAnim.GetBool("IsWalking");

        // calculate camera relative direction
        CamForward = Vector3.Scale(mainCam.forward, new Vector3(1, 0, 1)).normalized;

        // creating variable for forward movement relative to camera direction
        rightDirection = joystick.Vertical * CamForward + joystick.Horizontal * mainCam.right;

        // myRb.velocity = new Vector3(joystick.Horizontal * veloRate, myRb.velocity.y, joystick.Vertical * veloRate);
        // make character face same direction as camera
        // myRb.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up - Camera.main.transform.position, Vector3.up);

        // make character face same direction as joystick with smooth transition
        lookDirection = (new Vector3(rightDirection.x, 0, rightDirection.z));
        // determine method of rotation

        if (rightDirection.x != 0 || rightDirection.y != 0)
        {
            LegRotationObject.SetActive(true);

            //LegAnim.SetBool("IsWalking", StartWalk);

            // create a smooth direction to look at using Slerp()
            Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDirection*-1, turnSpeed * Time.deltaTime);
            //Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDirection, turnSpeed * Time.deltaTime);

            // float turn = Input.GetAxis("Horizontal");
            //myRb.AddTorque(transform.up * turnSpeed * turn);

            // Vector3 smoothDir = Vector3.Slerp(transform.forward, rightDirection, turnSpeed * Time.deltaTime);

            transform.rotation = Quaternion.LookRotation(smoothDir);
            //myRb.AddTorque (Quaternion.LookRotation (smoothDir), ;
            // store the current smooth direction to use when the player is not providing input, otherwise snaps back to original rotation
            oldDirection = smoothDir;

            // slippery add force method
            //myRb.AddForce(new Vector3(rightDirection.x, 0, rightDirection.z) * (addForceRate * Time.deltaTime));

            //add arbitrary velocity method
            myRb.velocity = rightDirection * (veloRate * Time.deltaTime);
        }
        else
        {
            LegRotationObject.SetActive(false);

            //LegAnim.SetBool("IsWalking", StartWalk);

            transform.rotation = Quaternion.LookRotation(oldDirection + adjustment);

            // slippery add force method
            //myRb.AddForce(new Vector3(rightDirection.x, 0, rightDirection.z) * (addForceRate * Time.deltaTime));

            // add arbitrary velocity method
            myRb.velocity = rightDirection * (veloRate * Time.deltaTime);
        }

        //camera swipe

        CameraAngleX += TouchField.TouchDist.x * CameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleX, Vector3.up) * new Vector3(0, 12, -30);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 7f - Camera.main.transform.position, Vector3.up);

    }
}
