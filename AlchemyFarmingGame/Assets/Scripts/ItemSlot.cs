using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //DESCRIPTION:
    //This script primarily functions as a buffer between item scripts and the inventory system
    //This script holds a bool which item scripts can reference as a trigger
    //It also stores basic UI information for an item, such as name, sprite, quantity, etc
    //Note: None of these variables should be edited on their own - they will be automatically populated by item scripts



    //VARIABLES:
    private Transform invUI; //References the inventory UI
    private int index; //What slot number this object is

    [Header("Item Info")]
    public string title; //Item name
    public Sprite icon; //Item UI icon
    public string desc; //Description of the item
    public string type; //What category of item this is
    public int stack; //How many max per stack
    public bool consummable; //Will item be deleted upon use?
    

    [Header("Technical")]
    public int bites; //How many uses this item has left
    public int quant = 1; //How many the player currently has
    public int addQuant; //A special field used for adding extra items to a stack
    public bool itemUse; //Item scripts will reference this as a trigger to determine whether they should start
    public Sprite empty; //A blank sprite
    public bool pickup; //Turns off some functionality if this is part of an item pickup

    private void Start()
    {
        invUI = GameObject.Find("InventoryUI").transform;
        index = transform.GetSiblingIndex();
    }

    private void Update()
    {
        if (transform.childCount == 0 || quant <= 0)
        {
            //If there's no item in this slot

            if (quant <= 0)
            {
                //If items have been used up (aka not just moved to a diff slot)
                //Destroy item object
                Destroy(transform.GetChild(0).gameObject);
            }

            //Clear all the values
            title = "";
            icon = null;
            desc = "";
            quant = 1;
            stack = 0;
            itemUse = false;
            consummable = false;

            //Clear the UI sprite
            invUI.GetChild(index).GetChild(0).GetComponent<Image>().sprite = empty;

            
        } else
        {
            //If there is an item in this slot
            if (icon != null && !pickup)
            {
                //If the item has already passed along its values and it's not just a pickup slot
                //Look up the UI slot and assign its icon
                invUI.GetChild(index).GetChild(0).GetComponent<Image>().sprite = icon;
                //FIX LATER WHEN HOTBAR & INV ARE DIFFERENT
                //If index is <= than # in hotbar, assign hotbar icon too
            }
        }
    }

}
