using UnityEngine;
using System.Collections;
using System.Security;

public class rotAround : MonoBehaviour
{

    public float rotx;
    public float roty;
    public float rotz;

    void FixedUpdate () 
    {
        //transform.Rotate (new Vector3 (rotx, roty, rotz) * Time.deltaTime);
        transform.Rotate(rotx, roty, rotz);
    }
}
        