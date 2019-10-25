using UnityEngine;

/* This object updates the inventory UI. */

public class KnowUI : MonoBehaviour {

    /*public Transform itemsParent;	// The parent object of all the items
    public GameObject knowUI;	// The entire UI

    KnowManager inventory;	// Our current inventory

    KnowledgeSlot[] slots;	// List of all the slots

    void Start () {
        inventory = KnowManager.instance;
        inventory.onItemChangedCallback += UpdateUI;	// Subscribe to the onItemChanged callback

        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<KnowledgeSlot>();
    }
	
    void Update () {
        // Check to see if we should open/close the inventory
        if (Input.GetButtonDown("Inventory"))
        {
            knowUI.SetActive(!knowUI.activeSelf);
        }
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    void UpdateUI ()
    {
        // Loop through all the slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)	// If there is an item to add
            {
                slots[i].AddItem(inventory.items[i]);	// Add it
            } else
            {
                // Otherwise clear the slot
                slots[i].ClearSlot();
            }
        }
    }*/
}
