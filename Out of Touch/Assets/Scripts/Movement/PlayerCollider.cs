using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public static bool Grounded;
    
    void OnTriggerStay (Collider col){ //if the groundcheck is inside the ground or an object with a collider
        Grounded = true;
    }


    void OnTriggerExit (Collider col){ //if the groundcheck is NOT inside the ground or an object with a collider
        Grounded = false;
    }

    private bool m_IsOnGround;
 
    public bool IsOnGround
    {
        get
        {
            if (m_IsOnGround)
            {
                m_IsOnGround = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    void OnCollisionStay()
    {
        //If it touch things, then it's on ground, that's my rule
        m_IsOnGround = true;
    }
}