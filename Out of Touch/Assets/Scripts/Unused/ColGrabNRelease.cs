using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColGrabNRelease : MonoBehaviour
{
    
    private bool raising;
    public GameObject animSource;
    
        
    public GameObject objectToGrab;
    private Rigidbody myRb;
   
    public AudioSource myAudio;
    public Image imageToShow;
  
    public bool showImage;
    public bool carrying;
    
    public Color originalColor;
    
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        carrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DoToggle()
    {
        if (!raising)
        {
            pickup();
            raising = true;
            GetComponent<SphereCollider>().enabled = true;
        }

        else if (raising)
        {
            drop();
            raising = false;
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    public void pickup()
    {
        Animator anim = animSource.GetComponent<Animator>();
        if (anim != null)
        {
            bool raiseHands = anim.GetBool("grabbing");
            Debug.Log("i got grabbing bool");
            anim.SetBool("grabbing", !raiseHands);
            Debug.Log("grabbing should be true now");
        }

        if (objectToGrab != null)
            {
                if (!carrying)
                {
                    FixedJoint grabJoint = objectToGrab.AddComponent<FixedJoint>();
                    //SpringJoint grabJoint = objectToGrab.AddComponent<SpringJoint>();
                    grabJoint.connectedBody = myRb;
                    grabJoint.breakForce = 9000;
                    grabJoint.enablePreprocessing = false;
                    //grabJoint.spring = 750f;
// for each loop a list, if list.this index does not exist then do the following then add this index to list and dont do the following for this index again
                    showImage = true;
                    if (showImage)
                    {
                        StartCoroutine(ShowAndHide(imageToShow, 5.0f));
                    }

                    carrying = true;
               }

            }
        }
    

    public void drop()
    {
        Animator anim = animSource.GetComponent<Animator>();
        if (anim != null)
        {
            bool raiseHands = anim.GetBool("grabbing");
            anim.SetBool("grabbing", !raiseHands);
        }
        
        Destroy(objectToGrab.GetComponent<FixedJoint>());
        //Destroy(objectToGrab.GetComponent<SpringJoint>());
        objectToGrab = null;
        carrying = false;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {

            objectToGrab = other.gameObject;
            
        }
        
    }
    
   /* public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {

            objectToGrab = null;
        }
        
    }*/
    
    IEnumerator ShowAndHide( Image go, float delay )
    {
        go.enabled = (true);
        myAudio.Play ();
        yield return new WaitForSeconds(delay);
        go.enabled = (false);
    }
}
