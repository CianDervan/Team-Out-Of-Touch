using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarraghCharacterMovementScript : MonoBehaviour
{

    public HingeJoint HJ;
    public Transform pos;
    public bool Inveter;

    // Update is called once per frame
    void Update()
    {
        JointSpring JS = HJ.spring;

        JS.targetPosition = pos.transform.localEulerAngles.x;

        if (JS.targetPosition > 180)
        {
            JS.targetPosition = JS.targetPosition - 360;
        }

        JS.targetPosition = Mathf.Clamp(JS.targetPosition, HJ.limits.min + 5, HJ.limits.max - 5);

        if (Inveter)
        {
            JS.targetPosition = JS.targetPosition * -1;
        }

        HJ.spring = JS;
    }
}
