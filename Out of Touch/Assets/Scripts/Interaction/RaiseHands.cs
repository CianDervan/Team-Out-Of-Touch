using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseHands : MonoBehaviour
{
    private bool raising;
    public GameObject animSource;
    
    public void DoToggle()
    {
        if (!raising)
        {
            pickup();
            raising = true;
            GetComponent<SphereCollider>().enabled = true;
        }

        else if (raising)
        {
            drop();
            raising = false;
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    public void pickup()
    {
        Animator anim = animSource.GetComponent<Animator>();
        if (anim != null)
        {
            bool raiseHands = anim.GetBool("grabbing");
            //Debug.Log("i got grabbing bool");
            anim.SetBool("grabbing", !raiseHands);
            //Debug.Log("grabbing should be true now");

        }
    }

    public void drop()
    {
        Animator anim = animSource.GetComponent<Animator>();
        if (anim != null)
        {
            bool raiseHands = anim.GetBool("grabbing");
            anim.SetBool("grabbing", !raiseHands);
            
        }
    }
}
