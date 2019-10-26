using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKnowledge : MonoBehaviour
{

    public Image KnowledgeImage;
    //public Sprite KnowledgeSprite;

    //private SpriteRenderer SpriteRenderer;

    private buttonGrabLG SK_buttonGrabLG;

    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer = GetComponent<SpriteRenderer>();

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
        

        /*if (SK_buttonGrabLG.KnowledgeAcquiredbGLG == true)
        { 
            SpriteRenderer.sprite = KnowledgeSprite;
            Debug.Log("Knowledge Acquired!");
        }*/


    }

}
