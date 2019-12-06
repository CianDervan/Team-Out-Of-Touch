using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformParent : MonoBehaviour
{
    public GameObject originalParent;
    public GameObject objectToAttach;
    // Start is called before the first frame update
    void Start()
    {
        objectToAttach.transform.parent = originalParent.transform;
    }

   /* public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        if (other.gameObject == objectToAttach)
        {
            Debug.Log("trigger entered");
            //other.transform.parent = transform;
            objectToAttach.transform.parent = transform;
            //other.transform.localScale = originalParent.transform.localScale;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        if (other.gameObject == objectToAttach)
        {
            Debug.Log("trigger exited");
            //objectToAttach.transform.parent = originalParent.transform;
            objectToAttach.transform.parent = null;
            //other.transform.parent = originalParent.transform;
            //other.transform.parent = null;
        }
    }*/
   public void OnCollisionEnter(Collision other)
   {
       //if (other.gameObject.CompareTag("Player"))
       if (other.gameObject == objectToAttach)
       {
           Debug.Log("collision entered");
           //other.transform.parent = transform;
           objectToAttach.transform.parent = transform;
           //other.transform.localScale = originalParent.transform.localScale;
       }
   }
   
   public void OnCollisionExit(Collision other)
   {
       //if (other.gameObject.CompareTag("Player"))
       if (other.gameObject == objectToAttach)
       {
           Debug.Log("collision exited");
           //objectToAttach.transform.parent = originalParent.transform;
           objectToAttach.transform.parent = null;
           //other.transform.parent = originalParent.transform;
           //other.transform.parent = null;
       }
       
   }

}
