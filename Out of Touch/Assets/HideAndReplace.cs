using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndReplace : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject theHips;
    public GameObject theTorso;
    public float lerpSpeed = 1f;
    
    Vector3 outOfReach = new Vector3(0,30,0);

    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Storage") && thisObject.gameObject.CompareTag("Storage Marker") 
            || (other.gameObject.CompareTag("Catchment") && thisObject.gameObject.CompareTag("Catchment Marker")
                || (other.gameObject.CompareTag("Rooftop") && thisObject.gameObject.CompareTag("Rooftop Marker")
                    || (other.gameObject.CompareTag("Suction") && thisObject.gameObject.CompareTag("Suction Marker")))))
        {
            Score.boxesCollected += 1;
            FindObjectOfType<RaiseHands>().DoToggle();
            theHips.GetComponent<Rigidbody>().freezeRotation = false;
            theTorso.GetComponent<Rigidbody>().freezeRotation = false;
            Destroy(other.GetComponent<FixedJoint>());
            GetComponent<MeshRenderer>().enabled = false;
            Vector3 moveSmooth = Vector3.Lerp(other.transform.position, transform.position + outOfReach, lerpSpeed * Time.deltaTime);
            other.transform.position = moveSmooth;
            other.GetComponent<Rigidbody>().isKinematic = true;
            //other.GetComponent<Rigidbody>().freezeRotation = true;
            //other.GetComponent<Rigidbody>()
            if (Score.timer >= 150)
            {
                Score.points += 101;
            }
            if (Score.timer <= 150 && Score.timer >= 120)
            {
                Score.points += 81;
            }
            if (Score.timer <= 120 && Score.timer >= 90)
            {
                Score.points += 61;
            }
            if (Score.timer <= 90 && Score.timer >= 60)
            {
                Score.points += 41;
            }
            if (Score.timer <= 60 && Score.timer >= 30)
            {
                Score.points += 21;
            }
            if (Score.timer <= 30)
            {
                Score.points += 6;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
