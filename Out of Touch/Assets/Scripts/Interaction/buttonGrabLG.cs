using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonGrabLG : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;

    public GameObject animSource;

    public GameObject springyHand;
    public Transform guide;                                 //player position
    bool carrying;
    public float range = 5;

    public Color originalColor;
    public Button grabbyButton;

    public Image imageToShow;
    public AudioSource myAudio;
    public bool  showText, showImage, playAudio;

    private ShowKnowledge gLg_ShowKnowledge;
    public GameObject KnowledgeSprite;

    // Start is called before the first frame update
    void Start()
    {
        gLg_ShowKnowledge = KnowledgeSprite.GetComponent<ShowKnowledge>();

        //grabbyButton.onClick.AddListener(TaskOnClick);
        grabbyButton.onClick.AddListener(DoToggle);
        item.GetComponent<Rigidbody>().useGravity = true;
        originalColor = item.GetComponent<Renderer>().material.color;
    }
    // Update is called once per frame
    void Update()
    {

    }


    void TaskOnClick()
    {

        Debug.Log("You have clicked the button!");

        if (carrying)
        {
            drop();
        }
        else
        {
            pickup();
        }

    }


    public void DoToggle()
    {
        //Debug.Log("You have clicked the button!");
        if (carrying == false && (guide.transform.position - transform.position).sqrMagnitude < range * range)                          //if distance from player to object is less than the range
        {
            pickup();
            carrying = true;
        }

        else if (carrying == true)
        {
            drop();
            carrying = false;
        }
    }

    public void pickup()
    {
        /*if (item != null)
        {
           // animSource.get
            Animator anim = animSource.GetComponent<Animator>();
            if (anim != null)
            {
                bool grabNow = anim.GetBool("grabbing");
                anim.SetBool("grabbing", !grabNow); //!isOpen);
            }
        }*/


        item.GetComponent<Renderer>().material.color = Color.green;

        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
        item.GetComponent<BoxCollider>().enabled = false;
        guide.GetComponent<BoxCollider>().enabled = true;
        guide.transform.localScale = item.transform.localScale;
        showImage = true;
        if (showImage)
        {
            StartCoroutine( ShowAndHide(imageToShow, 5.0f) );
        }

        /*item.AddComponent<SpringJoint>();
        item.GetComponent<SpringJoint>().connectedBody = springyBody.GetComponent<Rigidbody>();
        item.GetComponent<SpringJoint>().enablePreprocessing = false;
        item.GetComponent<SpringJoint>().spring = 750f;*/

        gLg_ShowKnowledge.KnowledgeIsAcquired(KnowledgeAcquired: true);
        Debug.Log("Player is Carrying");

        //bGLG_ShowKnowledge.KnowledgeAcquired = true;
        //KnowledgeAcquiredbGLG = true;

        //Debug.Log("Player is Carrying");

        /*if (showText) {
            StartCoroutine ("SetText");
        }

        if (playAudio) {
            myAudio.Play ();

            if (showImage) {
                imageToShow;
        }*/

        //item.AddComponent<FixedJoint>();
        //item.GetComponent<FixedJoint>().connectedBody = springyHand.GetComponent<Rigidbody>();
        //item.GetComponent<FixedJoint>().enablePreprocessing = false;
        //item.GetComponent<SpringJoint>().spring = 750f;

    }

    public void drop()
    {
       /* if (item != null)
        {
            Animator anim = animSource.GetComponent<Animator>();
            if (anim != null)
            {
                bool grabNow = anim.GetBool("grabbing");
                anim.SetBool("grabbing", !grabNow); //!isOpen);
            }
        }*/


        item.GetComponent<Renderer>().material.color = originalColor;

        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
        //StartCoroutine ("ResetCollider");
        guide.GetComponent<BoxCollider>().enabled = false;
        item.GetComponent<BoxCollider>().enabled = true;
        item.GetComponent<Rigidbody>().mass = 5000;
        //showImage = false;
        StopCoroutine( ShowAndHide(imageToShow, 5.0f) );

    }
    IEnumerator ShowAndHide( Image go, float delay )
    {
        go.enabled = (true);
        myAudio.Play ();
        yield return new WaitForSeconds(delay);
        go.enabled = (false);
    }
}
