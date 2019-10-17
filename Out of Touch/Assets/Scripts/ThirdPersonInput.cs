﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{

    public FixedJoystick LeftJoystick;
   // public FixedJoystick RightJoystick;
    public FixedButton Button;
    public FixedTouchField TouchField;
    protected ThirdPersonUserControl Control;

    public float CameraAngle;
    public float CameraAngleSpeed = 0.2f;

    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();

    }

    // Update is called once per frame
    void Update()
    {
        Control.m_Jump = Button.Pressed;
        //Control.Hinput = LeftJoystick.inputVector.x;
        //Control.Vinput = LeftJoystick.inputVector.y;

        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        Control.Hinput = LeftJoystick.input.x;
        Control.Vinput = LeftJoystick.input.y;
        //CameraAngle += RightJoystick.input.x * CameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 15, -28);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

    }
}