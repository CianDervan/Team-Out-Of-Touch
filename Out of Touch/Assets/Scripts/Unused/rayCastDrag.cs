﻿using UnityEngine;
using System.Collections;

public class rayCastDrag : MonoBehaviour
{

    public GameObject myOriginHolder;
    bool isCarrying = false;
    public float maxDistance = 5f;

    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {

    }

    public void makeConnection()
    {
        // get hand to move toward object use movetowards
        // once hand reaches a certain distance create new empty at that transform
        // create fixed joint between new empty and object
        // parent empty to hand / make object move with hand

    }

    public void checkOneHandOrTwo()
    {
        // create fixed joint between new empty and object
        // check if one hand is true
        // while one hand is true object is red and immovable
        // if not one hand two hands is true
        // if two hands is true object is green and movable, (should ydir be frozen?)

    }
    public void letGo()
    {
        

    }

    private void Raycast()
    {
        Vector3 origin = myOriginHolder.transform.position;
        Vector3 direction = myOriginHolder.transform.forward;// * -1;

        // Debug.Log(myOriginHolder.transform.position);

        Debug.DrawRay(origin, direction * maxDistance, Color.red);

        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layerMask) && !isCarrying)
        {

            raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;

            //makeConnection();

            raycastHit.collider.GetComponent<Rigidbody>().mass = 10;
            raycastHit.collider.GetComponent<Rigidbody>().useGravity = true;
            raycastHit.collider.GetComponent<Rigidbody>().isKinematic = false;
            //raycastHit.collider.gameObject.AddComponent<FixedJoint>();
            //raycastHit.collider.GetComponent<FixedJoint>().connectedBody = GameObject.Find("Fingers.r.002").GetComponent<Rigidbody>();

            myOriginHolder.gameObject.AddComponent<SpringJoint>();
            myOriginHolder.GetComponent<SpringJoint>().connectedBody = raycastHit.collider.GetComponent<Rigidbody>();
            myOriginHolder.GetComponent<SpringJoint>().enablePreprocessing = false;
            myOriginHolder.GetComponent<SpringJoint>().spring = 750f;
            isCarrying = true;
            Debug.Log("is carrying is true");
            
            //angle = GameController.PLAYER.transform.rotation.eulerAngles.y + 
            //Vector3.Angle (Vector3.zero, this.transform.position - GameController.PLAYER.transform.position) - rotation;
           
        }
        
        /*else if (isCarrying)
        {

            myOriginHolder.GetComponent<FixedJoint>().connectedBody = null;
            Debug.Log("joint disconnected");

        }*/
       
    }

    void Update()
    {

        Raycast();
    }

}



