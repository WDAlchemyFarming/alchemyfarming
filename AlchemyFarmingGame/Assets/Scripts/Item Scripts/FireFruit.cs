using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFruit : MonoBehaviour
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

    [Header("Fire Fruit")] //Specific to this item
    public GameObject fireball; //Projectile which will be spawned
    private Transform player; //The player's transform


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

        //Define player
        player = GameObject.Find("Player").transform;
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


                //Create a fireball with velocity
                GameObject fb = Instantiate(fireball, player.position + player.forward*2 + new Vector3(0,1,0), Quaternion.identity);
                fb.GetComponent<Rigidbody>().velocity = player.forward * 10;
                
                
            }
        }
    }
}
