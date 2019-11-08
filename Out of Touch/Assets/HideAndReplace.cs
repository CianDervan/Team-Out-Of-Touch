using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndReplace : MonoBehaviour
{
    //public GameObject myObject;
    public float lerpSpeed = 1f;
    public KnowGrab myKnowGrabController;
    Vector3 outOfReach = new Vector3(0,30,0);

    //private MeshRenderer myRend = myObject.GetComponent<MeshRenderer>().materials = null; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Storage"))
        {
            //myKnowGrabController.BreakTheChain();
            Destroy(other.GetComponent<FixedJoint>());
            GetComponent<MeshRenderer>().enabled = false;
            Vector3 moveSmooth = Vector3.Lerp(other.transform.position, transform.position + outOfReach, lerpSpeed * Time.deltaTime);
            //other.transform.position = transform.position;
            other.GetComponent<Rigidbody>().isKinematic = true;
            //other.GetComponent<Rigidbody>()
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
