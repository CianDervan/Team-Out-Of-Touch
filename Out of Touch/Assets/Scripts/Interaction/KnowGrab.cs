using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnowGrab : MonoBehaviour{

    private Rigidbody myRb;
    
    public GameObject thisObject;
    public GameObject objectToGrab;
    public GameObject myHips;
   // public GameObject myOtherHand;
    public GameObject animSource;

    public GameObject holdOnTight;
   
    public AudioSource myAudio;
    public Image imageToShow;
    public Color originalColor;

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
 
   /* public bool iHaveNotBeenCollectedOne;// = true;
    public bool iHaveNotBeenCollectedTwo;// = true;//, updateImageTwo = true;
    public bool iHaveNotBeenCollectedThree;// = true;//, updateImageThree = true;
    public bool iHaveNotBeenCollectedFour;// = true;//, updateImageFour = true;*/

    public int immovableMass;
    public int moveableMass;

    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        //carrying = false;
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rooftop"))
        {
            objectToGrab = other.gameObject;
            originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
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

                    bool iHaveNotBeenCollected = true;

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
                   }

                   carrying = true;
                }
            }
        }
        if (other.gameObject.CompareTag("Storage"))
        {
            objectToGrab = other.gameObject;
            originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
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
            originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
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
            originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    myHips.GetComponent<Rigidbody>().freezeRotation = true;
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
                                transform.parent = other.transform;
                                FixedJoint grabJoint = thisObject.AddComponent<FixedJoint>();
                                myHips.GetComponent<Rigidbody>().freezeRotation = true;
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
        if (objectToGrab != null)
        {
            if (thisObject.GetComponent<SphereCollider>().enabled == false && carrying)//(objectToGrab.CompareTag("Interactable"))
            {
                Destroy(objectToGrab.GetComponent<FixedJoint>());
                myHips.GetComponent<Rigidbody>().freezeRotation = false;
                //Destroy(objectToGrab.GetComponent<ConfigurableJoint>());
                //Destroy(objectToGrab.GetComponent<SpringJoint>());

                objectToGrab.GetComponent<Rigidbody>().mass = immovableMass; //5000;
                objectToGrab.GetComponent<Renderer>().material.color = originalColor;
                objectToGrab.GetComponent<Rigidbody>().useGravity = true;
                objectToGrab.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        objectToGrab = null;
        carrying = false;
    }
    IEnumerator ShowAndHide( Image go, float delay )
    {
        go.enabled = (true);
        myAudio.Play ();
        yield return new WaitForSeconds(delay);
        go.enabled = (false);
    }
}
