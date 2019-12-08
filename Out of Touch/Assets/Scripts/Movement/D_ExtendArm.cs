﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_ExtendArm : MonoBehaviour
{
    public bool WantsToGrab = false;

    public float ArmForce = 100f;
    public Rigidbody PlayerHand;
    public Transform R_Object;

    // Start is called before the first frame update
    void Start()
    {
        float PlayerDist = Vector3.Distance(R_Object.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (WantsToGrab == true)
        {
            Vector3 direction = (R_Object.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            PlayerHand.AddForce(direction * ArmForce);
        }
    }
}