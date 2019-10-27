using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKnowledge : MonoBehaviour
{
    public Image KnowledgeImage;

    private buttonGrabLG SK_buttonGrabLG;

    void Start()
    {
        SK_buttonGrabLG = GetComponent<buttonGrabLG>();

        KnowledgeImage = GetComponent<Image>();
    }

    public void KnowledgeIsAcquired(bool KnowledgeAcquired = false)
    {
        if (KnowledgeAcquired == true)
        {
            KnowledgeImage.enabled = true;
            Debug.Log("Knowledge Acquired!");
        }
    }

    public void Update()
    {

    }

}
