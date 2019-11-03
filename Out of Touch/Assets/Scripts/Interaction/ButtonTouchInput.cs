using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTouchInput : MonoBehaviour
{
    public Color defaultColor;
    public Color selectedColor;
    private Material mat;

    private bool ObjectIsTouched = false;

    private int ObjectIsTouchedCounter = 1;                         //if <0 object was touched, if >0 object is not touched

    private ShowBasicKnowledge BTI_ShowBasicKnowledge;
    public GameObject BasicKnowledgeSprite;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        BTI_ShowBasicKnowledge = BasicKnowledgeSprite.GetComponent<ShowBasicKnowledge>();
    }

    private void OnTouchDown()
    {
        ObjectIsTouchedCounter = ObjectIsTouchedCounter * -1;

        BTI_ShowBasicKnowledge.BasicKnowledgeIsAcquired(BasicKnowledgeAcquired: true);
    }

    private void Update()
    {
        if (ObjectIsTouchedCounter > 0)
        {
            mat.color = selectedColor;
        }
        if (ObjectIsTouchedCounter < 0)
        {
            mat.color = defaultColor;
        }
    }
}
