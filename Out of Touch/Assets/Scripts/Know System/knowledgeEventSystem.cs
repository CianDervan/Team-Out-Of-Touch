using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knowledgeEventSystem : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        knowledgeObserver.OnPointOfInterestEntered += newKnowledge_OnPointOfInterestEntered;
    }

    private void OnDestroy()
    {
        knowledgeObserver.OnPointOfInterestEntered -= newKnowledge_OnPointOfInterestEntered;
    }

    private void newKnowledge_OnPointOfInterestEntered(knowledgeObserver poi)
    {
        string knowledgeKey = "New Knowledge " + poi.POIName;
        
        if (PlayerPrefs.GetInt(knowledgeKey) == 1)
            return;
        
        PlayerPrefs.SetInt(knowledgeKey, 1);
        Debug.Log("Unlocked " + poi.POIName);

    }

}
