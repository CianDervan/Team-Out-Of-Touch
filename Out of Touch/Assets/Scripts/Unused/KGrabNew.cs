using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class KGrabNew : MonoBehaviour
{

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
    public RawImage flyOverTwo;
    public RawImage flyOverThree;
    public RawImage flyOverFour;

    public GameObject imageToSetActiveOne;
    public GameObject imageToSetInactiveOne;
   
    public GameObject imageToSetActiveTwo;
    public GameObject imageToSetInactiveTwo;
    
    public GameObject imageToSetActiveThree;
    public GameObject imageToSetInactiveThree;
    
    public GameObject imageToSetActiveFour;
    public GameObject imageToSetInactiveFour;
    
    public bool showImage;
    public bool carrying;
 
    public bool iHaveNotBeenCollectedRooftop;// = true;
    public bool iHaveNotBeenCollectedStorage;// = true;//, updateImageTwo = true;
    public bool iHaveNotBeenCollectedCatchment;// = true;//, updateImageThree = true;
    public bool iHaveNotBeenCollectedSuction;// = true;//, updateImageFour = true;

    public int immovableMass;
    public int moveableMass;

    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        carrying = false;
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rooftop"))
        {
            objectToGrab = other.gameObject;
            //originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying && iHaveNotBeenCollectedRooftop)//(!carrying)
                {
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
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    //object.Addforce (player.v - object.v)/(object.mass*∆t)
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));
                    //objectToGrab.GetComponent<Rigidbody>().velocity = myRb.velocity;
                    //objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity);

                    /*bool iHaveNotBeenCollected = true;

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

                   carrying = true;
                   iHaveNotBeenCollectedRooftop = false;
                }

                if (!carrying && !iHaveNotBeenCollectedRooftop)
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
           // originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    //grabJoint.spring = 750f;
                    //objectToGrab.GetComponent<SpringJoint>().damper = 100f;
// for each loop a list, if list.this index does not exist then do the following then add this index to list and dont do the following for this index again
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    //objectToGrab.GetComponent<Rigidbody>().velocity = myRb.velocity;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));

                    bool iHaveNotBeenCollected = true;

                   if (iHaveNotBeenCollected) // && iHaveNotBeenCollectedTwo && iHaveNotBeenCollectedThree && iHaveNotBeenCollectedFour)
                   {
                       imageToSetActiveTwo.SetActive(true);
                       imageToSetInactiveTwo.SetActive(false);
                       showImage = true;
                       if (showImage)
                       {
                           StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                       }
                       iHaveNotBeenCollected = false;
                   }

                   carrying = true;
                }
            }
        }
        if (other.gameObject.CompareTag("Catchment"))
        {
            objectToGrab = other.gameObject;
            //originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    //grabJoint.spring = 750f;
                    //objectToGrab.GetComponent<SpringJoint>().damper = 100f;
// for each loop a list, if list.this index does not exist then do the following then add this index to list and dont do the following for this index again
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                    //objectToGrab.GetComponent<Rigidbody>().velocity = myRb.velocity;
                    objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                    / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));

                    bool iHaveNotBeenCollected = true;

                    if (iHaveNotBeenCollected) // && iHaveNotBeenCollectedTwo && iHaveNotBeenCollectedThree && iHaveNotBeenCollectedFour)
                   {
                       imageToSetActiveThree.SetActive(true);
                       imageToSetInactiveThree.SetActive(false);
                       showImage = true;
                       if (showImage)
                       {
                           StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                       }
                       iHaveNotBeenCollected = false;
                   }

                   carrying = true;
                }
            }
        }
        if (other.gameObject.CompareTag("Suction"))
        {
            objectToGrab = other.gameObject;
            //originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
                    myTorso.GetComponent<Rigidbody>().freezeRotation = true;
                    //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = Single.PositiveInfinity;
                    grabJoint.enablePreprocessing = false;
                    //grabJoint.spring = 750f;
                    //objectToGrab.GetComponent<SpringJoint>().damper = 100f;
// for each loop a list, if list.this index does not exist then do the following then add this index to list and dont do the following for this index again
                    objectToGrab.GetComponent<Renderer>().material.color = Color.green;
                    objectToGrab.GetComponent<Rigidbody>().mass = moveableMass;
                    objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                    objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
                    objectToGrab.GetComponent<Rigidbody>().freezeRotation = true;
                   //objectToGrab.GetComponent<Rigidbody>().velocity = myRb.velocity;
                   objectToGrab.GetComponent<Rigidbody>().AddForce(myRb.velocity - objectToGrab.GetComponent<Rigidbody>().velocity
                                                                   / (objectToGrab.GetComponent<Rigidbody>().mass * Time.deltaTime));

                   bool iHaveNotBeenCollected = true;

                   if (iHaveNotBeenCollected) // && iHaveNotBeenCollectedTwo && iHaveNotBeenCollectedThree && iHaveNotBeenCollectedFour)
                   {
                       imageToSetActiveFour.SetActive(true);
                       imageToSetInactiveFour.SetActive(false);
                       showImage = true;
                       if (showImage)
                       {
                           StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                       }
                       iHaveNotBeenCollected = false;
                   }

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
            }
            objectToGrab.GetComponent<Renderer>().material.color = originalColor;
        }

        if (holdOnTight != null)
        {
           if (thisObject.GetComponent<SphereCollider>().enabled == false && carrying)
           {
                //Physics.gravity = currentRotation;
                //enabledForcesManager.enabled = true;

                //myFoot.GetComponent<SphereCaster>().enabled = true;
                transform.parent = originalParent.transform;

            // originalParent.GetComponent<Rigidbody>().AddForce(transform.forward * 20000000);
            //myHips.GetComponent<Rigidbody>().AddRelativeForce(holdOnTight.transform.forward * holdOnTight.GetComponent<Rigidbody>().angularVelocity.z);
            //myHips.GetComponent<Rigidbody>().AddRelativeForce(holdOnTight.GetComponent<Rigidbody>().angularVelocity * 60000);
            myHips.GetComponent<Rigidbody>().AddRelativeForce(throwForce * Time.deltaTime);// / holdOnTight.transform.forward);
            //myCatapult.enabled = true;

            myCom.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            myHead.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            myTorso.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            myHips.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
            myHips.GetComponent<SpringJoint>().connectedBody = null;
            Physics.gravity = new Vector3(0,-750f,0);
            //myFoot.GetComponent<SphereCaster>().enabled = true;

            //originalParent.GetComponent<Rigidbody>().rotation = other.rigidbody.rotation;
            // thisObject.GetComponent<Rigidbody>().rotation = other.rigidbody.rotation;

            //transform.parent.GetComponent<Rigidbody>().AddForce(currentRotation * 1000);
            //myRb.AddExplosionForce(10000, myRb.position,20);//AddForceAtPosition(currentRotation * 10000, Vector3.forward, ForceMode.Impulse);//(currentRotation * Mathf.Abs(1000000));// * (Vector3.forward);// * 1000);
            //transform.parent != holdOnTight.transform;
            Destroy(thisObject.GetComponent<FixedJoint>());
            
           myHips.GetComponent<Rigidbody>().freezeRotation = false;
           myTorso.GetComponent<Rigidbody>().freezeRotation = false;
           
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
        objectToGrab = null;
        carrying = false;
        //objectToGrab.GetComponent<Renderer>().material.color = originalColor;
    }
    
    IEnumerator ShowAndHide( Image go, float delay )
    {
        go.enabled = (true);
        myAudio.Play ();
        yield return new WaitForSeconds(delay);
        go.enabled = (false);
    }
}