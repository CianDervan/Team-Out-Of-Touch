﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamFollow : MonoBehaviour
{
    public Transform target;

    //public float smoothSpeed = 0.125f; // 10f
    public float smoothSpeed = 10f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
       // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        
        transform.LookAt(target);
    }
}
