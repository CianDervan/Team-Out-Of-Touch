using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knowledgeObserver : MonoBehaviour
{
   public static event Action<knowledgeObserver> OnPointOfInterestEntered;

   [SerializeField]
   private string poiName;
   
   public string POIName
   {
      get { return poiName; }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (OnPointOfInterestEntered != null)
         OnPointOfInterestEntered(this);
   }
}
