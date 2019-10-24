using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayInPlace : MonoBehaviour
{

    public GameObject mainParent;
    public Rigidbody myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotx =  mainParent.transform.eulerAngles.x - transform.eulerAngles.x;
        float rotz = mainParent.transform.eulerAngles.z - transform.eulerAngles.z;
        Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotx, 0, rotz), 0.99f);
    }
}
