using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class colliderButtonGrab : MonoBehaviour
{
    public GameObject myOriginHolder;
     GameObject greatGrandChildGrabbyHand;
    public GameObject emptyJointHolder;

    private bool IsCarrying = false;
    
   /* public bool destroySelf, destroyOtherObject, showObject, showText, loadScene, playAudio;
    public GameObject objectToDestroy, objectToShow;
    public Text textBox;
    public string textToShow, sceneToLoad;
    public AudioSource myAudio;*/
    
    public float maxDistance = 5f;
    public FixedJoint joint;
    public GameObject collectable;

    [SerializeField]
    private LayerMask layerMask;

   /* void OnCollisionEnter (Collision collision )
    {
        if(collision.gameObject.GetComponent<Rigidbody>())
        {
 
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
        }
    }*/

    
    public void dropObject()
    {

        emptyJointHolder.transform.parent = null;
    }

    public void pickupObject(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && !IsCarrying)
        {
            //greatGrandChildGrabbyHand = this.gameObject.transform.GetChild(2).GetChild(2).GetChild(0).gameObject;// change this if code in hand
            greatGrandChildGrabbyHand = GameObject.Find("Fingers.r.002");
            Vector3 pointOfConnection = new Vector3(greatGrandChildGrabbyHand.transform.position.x - other.gameObject.GetComponent<Collider>().gameObject.transform.position.x,
                greatGrandChildGrabbyHand.transform.position.y - other.gameObject.GetComponent<Collider>().gameObject.transform.position.y,
                greatGrandChildGrabbyHand.transform.position.z - other.gameObject.GetComponent<Collider>().gameObject.transform.position.z);

            emptyJointHolder = new GameObject("jointBuddy");
            emptyJointHolder.transform.position = pointOfConnection;
            emptyJointHolder.AddComponent<Rigidbody>();
            emptyJointHolder.AddComponent<FixedJoint>();
            emptyJointHolder.GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Collider>().GetComponent<Rigidbody>();
            emptyJointHolder.transform.parent = greatGrandChildGrabbyHand.transform;

            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
            other.gameObject.GetComponent<Rigidbody>().mass = 1;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
           
            //other.gameObject.gameObject.AddComponent<FixedJoint>();
            //other.gameObject.GetComponent<FixedJoint>().connectedBody = GameObject.Find("Fingers.r.002").GetComponent<Rigidbody>();

            // myOriginHolder.gameObject.AddComponent<FixedJoint>();
            // myOriginHolder.GetComponent<FixedJoint>().connectedBody = raycastHit.collider.GetComponent<Rigidbody>();

            IsCarrying = true;
        }
    }

    void Start()
    {
        
    }
    
    
    void Update()
    {
       // DoToggle();

    }
    public void DoToggle()
    {
        if (IsCarrying)
        {
            dropObject();
        }
        else
        {
            pickupObject(null);
        }
    }

   /* void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Interactable")) {
                if (destroySelf) {
                    Destroy (gameObject);
                }
                if (destroyOtherObject) {
                    Destroy (objectToDestroy);
                }

                if (showObject) {
                    objectToShow.SetActive (true);
                }

                if (showText) {
                    StartCoroutine ("SetText");
                }

                if (playAudio) {
                    myAudio.Play ();
                }

                if (loadScene) {
                    SceneManager.LoadScene (sceneToLoad);
                }

            }
        }

        IEnumerator SetText(){
            textBox.text = textToShow;
            yield return new WaitForSeconds(5f);
            textBox.text = "";
        }*/
    
    public void makeConnection()
    {
        // get hand to move toward object use movetowards
        // once hand reaches a certain distance create new empty at that transform
        // create fixed joint between new empty and object
        // parent empty to hand / make object move with hand

    }

}
