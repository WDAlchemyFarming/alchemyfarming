using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFruit : MonoBehaviour
{
    //DESCRIPTION:
    //This script populates the ItemSlot holding it and runs a specific item action



    //VARIABLES:

    private ItemSlot slot;
    private string parentName;
    private Transform aimer;

    [Header("Descriptive Info")]
    public string title; //Item name
    public Sprite icon; //Item UI icon
    public string desc; //Description of the item

    [Header("Mechanic Info")]
    public string type; //What category of item this is
    public int stack; //How many max per stack
    public bool consummable; //Will item be deleted upon use?
    public bool useable; //Can this item be used?
    public int bites; //How many bites does this item currently have?
    public int quant; //What is this item's current quantity
    public int startBites; //How many uses this item starts with

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
        bites = startBites;
        slot.bites = startBites;
        quant = slot.quant;

        //Define parent name
        parentName = transform.parent.name;

        //Define player
        player = GameObject.Find("Player").transform;
        aimer = GameObject.Find("Aimer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.name != parentName)
        {
            //This acts as a trigger so it will only assign slot values when this changes parents
            parentName = transform.parent.name;
            //Define slot as parent's slot
            slot = GetComponentInParent<ItemSlot>();
            //Assign values to slot
            slot.title = title;
            slot.icon = icon;
            slot.desc = desc;
            slot.stack = stack;
            slot.consummable = consummable;
        }
        if (slot.addQuant != 0)
        {
            quant += slot.addQuant;
            slot.addQuant = 0;
        }

        slot.bites = bites;
        slot.quant = quant;

        if (slot.itemUse)
        {
            //If left click while this item is selected
            //Reset itemUse
            slot.itemUse = false;
            if (useable)
            {
                //If the item is useable
                if (consummable && quant > 0)
                {
                    //If this item is consummable and hasn't run out
                    if (bites > 1)
                    {
                        //If this isn't the last bite, subtract 1 from quantity
                        bites--;
                    } else
                    {
                        //If this is the last bite
                        quant--;
                        bites = startBites;
                    }
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool didHit = Physics.Raycast(ray, out hit);

                if (didHit)
                {
                    aimer.LookAt(hit.point + new Vector3(0,1,0));
                    //Create a fireball with velocity
                    GameObject fb = Instantiate(fireball, aimer.position + (aimer.forward * 2) + new Vector3(0, 1, 0), aimer.rotation);
                    fb.GetComponent<Rigidbody>().velocity = aimer.forward * 10;
                }

                
                
                
            }
        }
    }
}
