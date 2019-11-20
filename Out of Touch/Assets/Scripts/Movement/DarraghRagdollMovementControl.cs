using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarraghRagdollMovementControl : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider caps;
    public HingeJoint[] MorteJoint; // em algum outro tutorial ensinarei...
    [Space(20)]
    public CapsuleCollider collcap;

    public HingeJoint hj1, hj2;
    public JointSpring hs1, hs2;
    public float SpringMin = 30, SpringMax = 300;

    [Space(20)]
    public float Resistencia = 10;
    public Animator anim;
    bool Morto = false;
    public float Velocidade;

    [Space(20)]
    public bool AtivarAutoConserto;  //nao mecher, porem nao há necessidade de existir
    public Transform checkRootable; //nao mecher, porem nao há necessidade de existir
    public bool Corrigindo; // private will //nao mecher, porem nao há necessidade de existir
    public float MinRoot, MaxRoot; //o eixo X //nao mecher, porem nao há necessidade de existir
    public float Inclinaçao; //nao mecher, porem nao há necessidade de existir
    private bool prefeiçao; //nao mecher, porem nao há necessidade de existir
    private float pretime; //nao mecher, porem nao há necessidade de existir



    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > Resistencia)
        {
            caps.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            for (int x = 0; x < MorteJoint.Length; x++)
            {
                MorteJoint[x].useSpring = false;
            }
            anim.SetBool("Morreu", true);
            Morto = true;
        }
    }


    void Start()
    {
        Velocidade = GetComponent<Rigidbody>().velocity.magnitude;
        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();
        prefeiçao = true;

        hs1 = hj1.spring;
        hs2 = hj2.spring;
    }


    void Update()
    {
        if (!Morto)
        {

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("Morreu", false);

                hs1.spring = SpringMin;
                hs2.spring = SpringMin;

                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(0, -120 * Time.deltaTime, 0); // rotaçao nao realista, pode-se utilizar o rigbory.addtorque
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(0, 120 * Time.deltaTime, 0);// rotaçao nao realista, pode-se utilizar o rigbory.addtorque
                }
            }



            if (Input.GetKey(KeyCode.W) == false && Corrigindo == false)
            {
                anim.SetBool("Morreu", true);

                hs1.spring = SpringMax;
                hs2.spring = SpringMax;
            }
            if (Input.GetKey(KeyCode.S))
            {
                //traz;
            }

            if (Input.GetKey(KeyCode.A))
            {

            }
            if (Input.GetKey(KeyCode.D))
            {

            }
            hj1.spring = hs1;
            hj2.spring = hs2;
        }
    }
