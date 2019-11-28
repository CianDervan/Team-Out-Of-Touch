using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionGrab : MonoBehaviour
{
    
    public GameObject objectToGrab;
    public GameObject thisObject;
    private Rigidbody myRb;
   
    public AudioSource myAudio;
    public Image imageToShow;
  
    public bool showImage;
    public bool carrying;
    public bool timeToLetGo;
    
    public Color originalColor;
    

    // Start is called before the first frame update
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
            
        }
        
    }
    
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {

            objectToGrab = null;
        }
        
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (objectToGrab!=null)
        {
            if (!carrying)
            {
                FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                //FixedJoint grabJoint = thisObject.AddComponent<FixedJoint>();
                //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
                grabJoint.connectedBody = myRb;
                //Rigidbody grabRb = objectToGrab.AddComponent<Rigidbody>();
                //grabJoint.connectedBody = grabRb;
                grabJoint.breakForce = 9000;
                grabJoint.enablePreprocessing = false;
                //grabJoint.spring = 750f;
// for each loop a list, if list.this index does not exist then do the following then add this index to list and dont do the following for this index again
                showImage = true;
                if (showImage)
                {
                    StartCoroutine( ShowAndHide(imageToShow, 5.0f) );
                }
                carrying = true;
            }

            /*else if (timeToLetGo)
            {
                if (objectToGrab.CompareTag("Interactable"))
                {
                    Destroy(objectToGrab.GetComponent<FixedJoint>());
                    //Destroy(objectToGrab.GetComponent<SpringJoint>());
                }

                objectToGrab = null;
                carrying = false;
            }*/
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
               // objectToGrab = null;
                //carrying = false;
            }

        }
        timeToLetGo = true;
        //objectToGrab = null;
        carrying = false;
    }

    public void BreakIt()
    {
       timeToLetGo = true;
    }
    
    IEnumerator ShowAndHide( Image go, float delay )
    {
        go.enabled = (true);
        myAudio.Play ();
        yield return new WaitForSeconds(delay);
        go.enabled = (false);
    }
}
