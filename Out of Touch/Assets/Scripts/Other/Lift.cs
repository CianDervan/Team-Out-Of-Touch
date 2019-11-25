using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{

    public Rigidbody myPosition;
    
    public Vector3 moveUp;
    public float moveUpForce = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        moveUp = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        myPosition.AddForce(moveUp * moveUpForce, ForceMode.Impulse);
    }
}
