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

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void OnTouchDown()
    {
        //mat.color = selectedColor;
        //ObjectIsTouched = !ObjectIsTouched;
        ObjectIsTouchedCounter = ObjectIsTouchedCounter * -1;
    }

    void OnTouchUp()
    {
        //mat.color = defaultColor;
        //ObjectIsTouched = !ObjectIsTouched;
    }

    void OnTouchStay()
    {
        //mat.color = selectedColor;
        //ObjectIsTouched = true;
    }

    void OnTouchExit()
    {
        //mat.color = defaultColor;
        //ObjectIsTouched = false;
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
