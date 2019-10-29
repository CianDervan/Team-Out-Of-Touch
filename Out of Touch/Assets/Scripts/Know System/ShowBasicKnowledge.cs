using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBasicKnowledge : MonoBehaviour
{
    public Image BasicKnowledgeImage;

    private ButtonTouchInput SBK_ButtonTouchInput;

    void Start()
    {
        SBK_ButtonTouchInput = GetComponent<ButtonTouchInput>();

        BasicKnowledgeImage = GetComponent<Image>();
    }

    public void BasicKnowledgeIsAcquired(bool BasicKnowledgeAcquired = false)
    {
        if (BasicKnowledgeAcquired == true)
        {
            BasicKnowledgeImage.enabled = true;
            Debug.Log("Advanced Knowledge Acquired!");
        }
    }
}
