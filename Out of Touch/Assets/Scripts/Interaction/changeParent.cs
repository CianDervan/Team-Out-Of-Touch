using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeParent : MonoBehaviour
{
    public GameObject newParentObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lift"))
        {
            if (newParentObject != null)
            {
                transform.parent = newParentObject.transform;
            }
        }
    }
}
