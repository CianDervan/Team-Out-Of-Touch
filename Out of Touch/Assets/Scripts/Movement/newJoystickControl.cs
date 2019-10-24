﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newJoystickControl : MonoBehaviour
{
    public Joystick joystick;
    //public Joybutton joybutton;
   
    public float veloRate = 4.0f;

    public FixedTouchField TouchField;
    public float CameraAngleX;

    public float CameraAngleSpeed = 0.2f;

    public Rigidbody myRb;

    private Vector3 CamForward;
    private Transform mainCam;

    private Vector3 rightDirection;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;

        myRb = GetComponent<Rigidbody>();
        //joystick = FindObjectOfType<Joystick>();
        //joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate camera relative direction
        CamForward = Vector3.Scale(mainCam.forward, new Vector3(1, 0, 1)).normalized;
        
        rightDirection = joystick.Vertical * CamForward + joystick.Horizontal * mainCam.right;

        //myRb.velocity = new Vector3(joystick.Horizontal * veloRate, myRb.velocity.y, joystick.Vertical * veloRate);

        // forward movement relative to camera direction

        myRb.velocity = rightDirection * veloRate;
       // myRb.AddForce(new Vector3(rightDirection.x, 0, rightDirection.z) * veloRate);

        //camera swipe

        CameraAngleX += TouchField.TouchDist.x * CameraAngleSpeed;
       
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleX, Vector3.up) * new Vector3(0, 12, -30);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 7f - Camera.main.transform.position, Vector3.up);
        

    }
}