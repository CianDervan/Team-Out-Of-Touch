using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarraghCharacterMovementScript : MonoBehaviour
{

    public HingeJoint MHJ;
    public Transform Mpos;
    public bool MInveter;

    //public Transform IPos;

    // Update is called once per frame
    void Update()
    {
        JointSpring JS = MHJ.spring;

        JS.targetPosition = Mpos.transform.localEulerAngles.x;

        if (JS.targetPosition > 180)
        {
            JS.targetPosition = JS.targetPosition - 360;
        }

        JS.targetPosition = Mathf.Clamp(JS.targetPosition, MHJ.limits.min + 5, MHJ.limits.max - 5);

        if (MInveter)
        {
            JS.targetPosition = JS.targetPosition * -1;
        }

        MHJ.spring = JS;
    }
}
