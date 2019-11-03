using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewJointGrab : MonoBehaviour
{
  /*  private Rigidbody myRb;
    
    public GameObject thisObject;
    public GameObject objectToGrab;
    public GameObject animSource;
   
    public AudioSource myAudio;
    public Image imageToShow;
    public Color originalColor;

    //public GameObject newObject;
    
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
    public bool iHaveNotBeenCollectedFour;// = true;//, updateImageFour = true;
    
   // public Button grabbyButton;
   // public bool isGrab;

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
        if (other.gameObject.CompareTag("Interactable"))
        {
            objectToGrab = other.gameObject;
//            originalColor = objectToGrab.gameObject.GetComponent<Renderer>().material.color;

            if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
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
                    
                    showImage = true;
                    if (showImage)
                    {
                        StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                    }

                   bool iHaveNotBeenCollectedOne = true;
                   /* bool iHaveNotBeenCollectedOne;// = true;
                    bool iHaveNotBeenCollectedTwo;// = true;//, updateImageTwo = true;
                    bool iHaveNotBeenCollectedThree;// = true;//, updateImageThree = true;
                    bool iHaveNotBeenCollectedFour;// = true;//, updateImageFour = true;

                   if (iHaveNotBeenCollectedOne) // && iHaveNotBeenCollectedTwo && iHaveNotBeenCollectedThree && iHaveNotBeenCollectedFour)
                   {
                       imageToSetActiveOne.SetActive(true);
                       imageToSetInactiveOne.SetActive(false);
                       iHaveNotBeenCollectedOne = false;
                   }

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
    */
}
   