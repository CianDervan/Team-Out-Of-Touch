using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenuToggle : MonoBehaviour{
private bool cmOn = true;
public GameObject cmCanvas;

public void turnCMon()
{
cmCanvas.SetActive(true);
cmOn = true;
}
    
public void turnCMoff()
{
    cmCanvas.SetActive(false);
cmOn = false;
}
    
public void DoToggle()
{
if (cmOn)                        
{
    turnCMoff();
}

else if (!cmOn)
{
    turnCMon();
}
}
}