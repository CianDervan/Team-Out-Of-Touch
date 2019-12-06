using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuOpen : MonoBehaviour
{
   public GameObject MenuPanel;

   public void OpenMenu()
   {
      if (MenuPanel != null)
      {
         Score.canCount = false;
         Animator anim = MenuPanel.GetComponent<Animator>();
         if (anim != null)
         {
            bool isOpen = anim.GetBool("Open");
            anim.SetBool("Open", !isOpen);
         }
      }
   }
}
