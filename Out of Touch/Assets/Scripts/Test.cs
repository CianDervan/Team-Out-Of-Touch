using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public GameObject spinMe;
    public float RotateSpeed = 30f;
    public Transform target;

    public void OnPointerClick(PointerEventData eventData)
    {
        spinMe.transform.Rotate(-Vector3.up.normalized * RotateSpeed * Time.deltaTime);
        Debug.Log("I should be spinning");
    }
    
    public void SpinMe()
    {
        //spinMe.transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        //spinMe.transform.Rotate(0,RotateSpeed, 0);
        
        float step =  RotateSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        Debug.Log("I should be spinning");
    }
}