using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    //DESCRIPTION:
    //This script populates the ItemSlot holding it and runs a specific item action



    //VARIABLES:

    private ItemSlot slot;

    [Header("Descriptive Info")]
    public string title; //Item name
    public Sprite icon; //Item UI icon
    public string desc; //Description of the item

    [Header("Mechanic Info")]
    public int stack; //How many max per stack
    public bool consummable; //Will item be deleted upon use?
    public bool useable; //Can this item be used?

    // Start is called before the first frame update
    void Start()
    {
        //Define slot as parent's slot
        slot = GetComponentInParent<ItemSlot>();
        //Assign values to slot
        slot.title = title;
        slot.icon = icon;
        slot.desc = desc;
        slot.stack = stack;
        slot.consummable = consummable;
    }

    // Update is called once per frame
    void Update()
    {
        if (slot.itemUse)
        {
            //If left click while this item is selected
            //Reset itemUse
            slot.itemUse = false;
            if (useable)
            {
                //If the item is useable
                if (consummable)
                {
                    //If this item is consummable, subtract 1 from quantity
                    slot.quant--;
                }



                //INSERT ITEM EFFECT HERE

                
                
            }
        }
    }
}
