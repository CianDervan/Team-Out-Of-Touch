using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabLetgo : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    bool carrying;
    public float range = 5;

    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying == false)
        {
            if (Input.GetKeyDown(KeyCode.K) &&
                (guide.transform.position - transform.position).sqrMagnitude < range * range)
            {
                pickup();
                carrying = true;
            }
        }
        else if (carrying == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                drop();
                carrying = false;
            }
        }
    }

   public void pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
        item.GetComponent<BoxCollider>().enabled = false;
        guide.GetComponent<BoxCollider>().enabled = true;
    }

   public void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
        //StartCoroutine ("ResetCollider");
        guide.GetComponent<BoxCollider>().enabled = false;
        item.GetComponent<BoxCollider>().enabled = true;
        item.GetComponent<Rigidbody>().mass = 5000;
        
    }

   /* IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(3f);
        //item.GetComponent<BoxCollider>().enabled = true;
    }*/
}