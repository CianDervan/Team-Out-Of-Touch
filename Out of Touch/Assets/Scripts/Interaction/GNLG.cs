using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GNLG : MonoBehaviour
{
    //private bool raising;
    private bool WantsToGrab = false;

    public float ArmForce = 100f;
    public Rigidbody PlayerHand;
   // public Transform R_Object;
    public GameObject R_Object;

    public GameObject RightCollider;

    public void DoToggle()
    {
        if (!WantsToGrab)
        {
            pickup();
            WantsToGrab = true;
           // GetComponent<SphereCollider>().enabled = true;
        }

        else if (WantsToGrab)
        {
            drop();
            WantsToGrab = false;
          //  GetComponent<SphereCollider>().enabled = false;
        }
    }

    public void pickup()
    {
        R_Object.SetActive(true);
        Vector3 direction = (R_Object.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        PlayerHand.AddForce(direction * ArmForce);
            
        RightCollider.SetActive(true);
        
    }

    public void drop()
    {
        R_Object.SetActive(false);
        RightCollider.SetActive(false);
    }

/*

    void ExtendArms()
    {
        if (WantsToGrab == true)
        {
            Vector3 direction = (R_Object.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            PlayerHand.AddForce(direction * ArmForce);
            
            RightCollider.SetActive(true);
        }
    }

 */

}

