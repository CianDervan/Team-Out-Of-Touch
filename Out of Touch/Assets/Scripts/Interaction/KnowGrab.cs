using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class KnowGrab : MonoBehaviour
{

    public GameObject myFlyOCameraOne;
    public GameObject myFlyOCameraTwo;
    public GameObject myFlyOCameraThree;
    public GameObject myFlyOCameraFour;
   // public SphereCaster enabledForcesManager;
    private Rigidbody myRb;
    
    public Vector3 currentRotation;
    public Vector3 throwForce;

    public GameObject myCom;
    public GameObject myHead;
    public GameObject myTorso;
    public GameObject myHips;
  
    public GameObject myFoot;
    public GameObject thisObject;
    public GameObject originalParent;
    public GameObject objectToGrab;

   // public GameObject myOtherHand;
    public GameObject animSource;

    public GameObject holdOnTight;
   
    public AudioSource myAudio;
    public Image imageToShow;
    public Color originalColor;
    
    public RawImage flyOverOne;
    public GameObject flyOverOneButton;
    public RawImage flyOverTwo;
    public GameObject flyOverTwoButton;
    public RawImage flyOverThree;
    public GameObject flyOverThreeButton;
    public RawImage flyOverFour;
    public GameObject flyOverFourButton;

    public GameObject imageToSetActiveOne;
    public GameObject imageToSetInactiveOne;
   
    public GameObject imageToSetActiveTwo;
    public GameObject imageToSetInactiveTwo;
    
    public GameObject imageToSetActiveThree;
    public GameObject imageToSetInactiveThree;
    
    public GameObject imageToSetActiveFour;
    public GameObject imageToSetInactiveFour;
    
    public bool showImage;
    public bool showRawImage;
    public bool carrying;
 
    public bool iHaveNotBeenCollectedRooftop;
    public bool iHaveNotBeenCollectedStorage;
    public bool iHaveNotBeenCollectedCatchment;
    public bool iHaveNotBeenCollectedSuction;

    public int immovableMass;
    public int moveableMass;

    private Vector3 lastPos;
    
    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        carrying = false;
        iHaveNotBeenCollectedRooftop = true;
        iHaveNotBeenCollectedStorage = true;
        iHaveNotBeenCollectedCatchment = true;
        iHaveNotBeenCollectedSuction = true;
        //originalColor = objectToGrab.GetComponent<Renderer>().material.color;
    }

    private void LateUpdate()
    {
        lastPos = transform.position;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rooftop"))
        {
            objectToGrab = other.gameObject;
            //objectToGrab.GetComponent<Renderer>().material.color = Color.green;
            //originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
               // originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;
               
                if (!carrying && iHaveNotBeenCollectedRooftop)//(!carrying)
                {
                    //objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.green);
                    //objectToGrab.GetComponent<Renderer>().enabled = Color.green;
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    //ConfigurableJoint grabJointTwo = objectToGrab.AddComponent<ConfigurableJoint>();
                    //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
                    grabJoint.connectedBody = myRb;
                   // grabJointTwo.connectedBody = myOtherHand.GetComponent<Rigidbody>();
                   // grabJointTwo.projectionMode = JointProjectionMode.PositionAndRotation;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    //grabJoint.spring = 750f;
                    //objectToGrab.GetComponent<SpringJoint>().damper = 100f;
// for each loop a list, if list.this index does not exist then do the following then add this index to list and dont do the following for this index again
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    //object.Addforce (player.v - object.v)/(object.mass*∆t)
                    
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));
                    //objectToGrab.GetComponent<Rigidbody>().velocity = myRb.velocity;
                    //objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity);

                   /* bool iHaveNotBeenCollected = true;

                   if (iHaveNotBeenCollected) // && iHaveNotBeenCollectedTwo && iHaveNotBeenCollectedThree && iHaveNotBeenCollectedFour)
                   {
                       imageToSetActiveOne.SetActive(true);
                       imageToSetInactiveOne.SetActive(false);
                       showImage = true;
                       if (showImage)
                       {
                           StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                       }
                       iHaveNotBeenCollected = false;
                   }*/
                   
                   imageToSetActiveOne.SetActive(true);
                   imageToSetInactiveOne.SetActive(false);
                   showImage = true;
                   if (showImage)
                   {
                       StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                   }
                   showRawImage = true;
                   if (showRawImage)
                   {
                       myFlyOCameraOne.SetActive(true);
                       //StartCoroutine(ShowAndHideTwo(flyOverOne, 14.0f));
                       flyOverOne.enabled = true;
                       flyOverOneButton.SetActive(true);
                   }
                   
                   carrying = true;
                   iHaveNotBeenCollectedRooftop = false;
                }
               else if (!carrying && !iHaveNotBeenCollectedRooftop)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));
                    carrying = true;
                }
            }
        }
        if (other.gameObject.CompareTag("Storage"))
        {
            objectToGrab = other.gameObject;

            if (objectToGrab != null)
            {
                if (!carrying && iHaveNotBeenCollectedStorage)//(!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));
                    imageToSetActiveTwo.SetActive(true);
                    imageToSetInactiveTwo.SetActive(false);
                    showImage = true;
                    if (showImage)
                    {
                        StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                    }
                    showRawImage = true;
                    if (showRawImage)
                    {
                        myFlyOCameraTwo.SetActive(true);
                        //StartCoroutine(ShowAndHideTwo(flyOverTwo, 14.0f));
                        flyOverTwo.enabled = true;
                        flyOverTwoButton.SetActive(true);
                    }
                    carrying = true;
                    iHaveNotBeenCollectedStorage = false;
                }
                
                else if (!carrying && !iHaveNotBeenCollectedStorage)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));
                    carrying = true;
                    
                }
            }
        }
        if (other.gameObject.CompareTag("Catchment"))
        {
            objectToGrab = other.gameObject;

            if (objectToGrab != null)
            {
                if (!carrying && iHaveNotBeenCollectedCatchment)//(!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));

                    imageToSetActiveThree.SetActive(true);
                    imageToSetInactiveThree.SetActive(false);
                    showImage = true;
                    if (showImage)
                    {
                        StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                    }
                    showRawImage = true;
                    if (showRawImage)
                    {
                        myFlyOCameraThree.SetActive(true);
                        //StartCoroutine(ShowAndHideTwo(flyOverThree, 14.0f));
                        flyOverThree.enabled = true;
                        flyOverThreeButton.SetActive(true);
                    }
                    carrying = true;
                    iHaveNotBeenCollectedCatchment = false;
                }
                
                else if (!carrying && !iHaveNotBeenCollectedCatchment)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));
                    carrying = true;
                }
            }
        }
        if (other.gameObject.CompareTag("Suction"))
        {
            objectToGrab = other.gameObject;

            if (objectToGrab != null)
            {
                if (!carrying && iHaveNotBeenCollectedSuction)//(!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));

                    imageToSetActiveFour.SetActive(true);
                    imageToSetInactiveFour.SetActive(false);
                    showImage = true;
                    if (showImage)
                    {
                        StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                    }
                    showRawImage = true;
                    if (showRawImage)
                    {
                        myFlyOCameraFour.SetActive(true);
                        //StartCoroutine(ShowAndHideTwo(flyOverFour, 14.0f));
                        flyOverFour.enabled = true;
                        flyOverFourButton.SetActive(true);
                    }
                    carrying = true;
                    iHaveNotBeenCollectedSuction = false;
                }
                
                else if (!carrying && !iHaveNotBeenCollectedSuction)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));
                    carrying = true;
                }
            }
        }
                    if (other.gameObject.CompareTag("Interactable"))
                    {
                        holdOnTight = other.gameObject;

                        if (holdOnTight != null)
                        {
                            if (!carrying)
                            {
                                //enabledForcesManager.enabled = false;
                                //Physics.gravity = new Vector3(0, 0, 0);
                                //currentRotation = myRb.angularVelocity;
                                
                                //currentRotation = holdOnTight.GetComponent<Rigidbody>().angularVelocity;
                                
                                myFoot.GetComponent<SphereCaster>().enabled = false;
                                transform.parent = other.transform;
                                FixedJoint grabJoint = thisObject.AddComponent<FixedJoint>();
                                
                                //FixedJoint grabJoint = myHips.AddComponent<FixedJoint>();
                                
                                //myHips.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 600000);
                                                                
                                //originalParent.GetComponent<Rigidbody>().rotation = other.rigidbody.rotation;
                                //myHips.GetComponent<Rigidbody>().rotation = other.rigidbody.rotation;
                                
                               //Vector3 throwMeThisWay = new Vector3(other.transform.forward.z, other.transform.up.y);
                                   // myHips.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(
                                   // other.transform.forward, other.transform.up);
                                
                                myHips.GetComponent<Rigidbody>().freezeRotation = true;
                                myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                                
                                //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
                                
                                grabJoint.connectedBody = holdOnTight.GetComponent<Rigidbody>();
                                grabJoint.breakForce = Single.PositiveInfinity;
                                grabJoint.enablePreprocessing = false;
                                
                                //grabJoint.spring = 750f;
                                //objectToGrab.GetComponent<SpringJoint>().damper = 100f;
                                //holdOnTight.GetComponent<Rigidbody>().mass = immovableMass;
                                // objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                                // objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                                carrying = true;
                            }
                        }
                    }
    }
    
    public void BreakTheChain()
    {
        if (objectToGrab != null)// || holdOnTight != null)
        {
            if (carrying)//(thisObject.GetComponent<SphereCollider>().enabled == false && carrying)//(objectToGrab.CompareTag("Interactable"))
            {
                Destroy(objectToGrab.GetComponent<FixedJoint>());
                myHips.GetComponent<Rigidbody>().freezeRotation = false;
                myTorso.GetComponent<Rigidbody>().freezeRotation = false;
                //Destroy(objectToGrab.GetComponent<ConfigurableJoint>());
                //Destroy(objectToGrab.GetComponent<SpringJoint>());

                objectToGrab.GetComponent<Rigidbody>().mass = immovableMass; //5000;
                objectToGrab.GetComponent<Renderer>().material.color = originalColor;
                objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                
                objectToGrab.GetComponent<Renderer>().material.color = originalColor;
                showRawImage = false;
            }
            objectToGrab.GetComponent<Renderer>().material.color = originalColor;
        }

        //Let go of interactable
        if (holdOnTight != null)
        {
            
           if (thisObject.GetComponent<SphereCollider>().enabled == false && carrying)
           {
                //Physics.gravity = currentRotation;
                //enabledForcesManager.enabled = true;

                myFoot.GetComponent<SphereCaster>().enabled = true;
                transform.parent = originalParent.transform;

            // originalParent.GetComponent<Rigidbody>().AddForce(transform.forward * 20000000);
            //myHips.GetComponent<Rigidbody>().AddRelativeForce(holdOnTight.transform.forward * holdOnTight.GetComponent<Rigidbody>().angularVelocity.z);
            //myHips.GetComponent<Rigidbody>().AddRelativeForce(holdOnTight.GetComponent<Rigidbody>().angularVelocity * 60000);
            //myHips.GetComponent<Rigidbody>().AddRelativeForce(throwForce * Time.deltaTime);// / holdOnTight.transform.forward);
            //myCatapult.enabled = true;

            //myCom.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            //myHead.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            //myTorso.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            //myHips.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            //myHips.GetComponent<SpringJoint>().connectedBody = null;
            //Physics.gravity = new Vector3(0,-750f,0);
            //myFoot.GetComponent<SphereCaster>().enabled = true;

            //originalParent.GetComponent<Rigidbody>().rotation = other.rigidbody.rotation;
            // thisObject.GetComponent<Rigidbody>().rotation = other.rigidbody.rotation;

            //transform.parent.GetComponent<Rigidbody>().AddForce(currentRotation * 1000);
            //myRb.AddExplosionForce(10000, myRb.position,20);//AddForceAtPosition(currentRotation * 10000, Vector3.forward, ForceMode.Impulse);//(currentRotation * Mathf.Abs(1000000));// * (Vector3.forward);// * 1000);
            //transform.parent != holdOnTight.transform;
            Destroy(thisObject.GetComponent<FixedJoint>());
            
           myHips.GetComponent<Rigidbody>().freezeRotation = false;
           myTorso.GetComponent<Rigidbody>().freezeRotation = false;


           var throwVector =  myHips.GetComponent<Rigidbody>().velocity.normalized;
           myHips.GetComponent<Rigidbody>().AddForce(throwVector * 20000f, ForceMode.Impulse);
           
            //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
            //grabJoint.spring = 750f;
            //objectToGrab.GetComponent<SpringJoint>().damper = 100f;
            //holdOnTight.GetComponent<Rigidbody>().mass = immovableMass;
            // objectToGrab.GetComponent<Rigidbody>().useGravity = true;
            // objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
            //carrying = true;
            //carrying = false;
        }
    }

       // myCatapult.enabled = false;
        showRawImage = false;
        objectToGrab = null;
        carrying = false;
        StopCoroutine(ShowAndHideTwo(null, 0f));
        //objectToGrab.GetComponent<Renderer>().material.color = originalColor;
    }
    
    IEnumerator ShowAndHide( Image go, float delay )
    {
        go.enabled = (true);
        myAudio.Play ();
        yield return new WaitForSeconds(delay);
        go.enabled = (false);
    }
    
    IEnumerator ShowAndHideTwo( RawImage go, float delay )
    {
        go.enabled = (true);
        //myAudio.Play ();
        yield return new WaitForSeconds(delay);
        go.enabled = (false);
    }
}
