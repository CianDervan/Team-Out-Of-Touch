using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //public Animator StaticAnimator;
    public float speed;

    public GameObject COMConnector;
    private Rigidbody rb;
    public Rigidbody hips;

    public ConstantForce[] uprightforces;
    public bool upright = true;

    Vector3 dirLeft = new Vector3(0, -2500, 0);
    Vector3 dirRight = new Vector3(0, 2500, 0);
    

    void Awake()
    {
        upright = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float collisionForce;

    private void OnCollisionEnter(Collision collision)
    {
        collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;

        if (collisionForce > 100.0F)
        {
            upright = false;
            //COMConnector.GetComponent<FixedJoint>().connectedBody = null;
            // hips.AddForce(hips.transform.forward * speed);
            hips.AddForce(hips.transform.forward * collision.impulse.magnitude / Time.fixedDeltaTime);
        }
        /*else if (collisionForce < 200.0F) {
            upright = false;
        }
        else {
            // This collision killed me!
        }
    }*/


        void FixedUpdate()
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(dirLeft * Time.deltaTime);
            Quaternion deltaRotationRight = Quaternion.Euler(dirRight * Time.deltaTime);

            if (upright)
            {
                uprightforces[0].enabled = true; // com
                uprightforces[1].enabled = true; // head
                uprightforces[2].enabled = true; // torso
                uprightforces[3].enabled = true; // hips
            }

            if (!upright)
            {
                uprightforces[0].enabled = false; // com
                uprightforces[1].enabled = false; // head
                uprightforces[2].enabled = false; // torso
                uprightforces[3].enabled = false; // hips
            }

            if (Input.GetKey(KeyCode.W))
            {
                hips.AddForce(hips.transform.forward * speed);
                // StaticAnimator.SetBool("isWalk", true);
                // StaticAnimator.SetBool("sway_arms", true);
            } //else {StaticAnimator.SetBool("isWalk", false); StaticAnimator.SetBool("sway_arms", true);}

            if (Input.GetKey(KeyCode.A))
            {
                hips.MoveRotation(hips.rotation * deltaRotationLeft);
            }

            if (Input.GetKey(KeyCode.S))
            {
                hips.AddForce(-hips.transform.forward * speed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                hips.MoveRotation(hips.rotation * deltaRotationRight);
            }

            if (Input.GetKey(KeyCode.F))
            {
                upright = false;
            }
            else
            {
                upright = true;
            }
        }
    }
}