using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    //DESCRIPTION:
    //This script allows players to select items on the hotbar ("Belt") using the scroll wheel
    //It interfaces with an object in the game called "Inventory" which houses player items
    //When a player clicks with an item selected, it activates in its respective item
    //This bool acts as a trigger, telling the item to perform its unique action

    
    
    //VARIABLES:
    private Transform inv; //This references the Inventory object's transform

    [Header("Selection")]
    public int currentSlot = 0; //An int defining which slot we have selected
    public Sprite deselSprite; //Deselected sprite
    public Sprite selSprite; //Selected sprite



    //ACTUAL CODE:
    // Start is called before the first frame update
    void Start()
    {
        //Assigns inv by searching the Inventory object
        inv = GameObject.Find("Inventory").transform;
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            //If mouse scrolls backward
            //Switches sprite of old selection, adds 1 to currentSlot, switches sprite of new selection
            transform.GetChild(currentSlot).GetComponent<Image>().sprite = deselSprite;
            currentSlot++;
            if (currentSlot >= transform.childCount)
            {
                //If slot is higher than maximum, resets to 0
                currentSlot = 0;
            }
            transform.GetChild(currentSlot).GetComponent<Image>().sprite = selSprite;

        } else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //If mouse scrolls forward
            //Switches sprite of old selection, subtracts 1 from currentSlot, switches sprite of new selection
            transform.GetChild(currentSlot).GetComponent<Image>().sprite = deselSprite;
            currentSlot--;
            if (currentSlot < 0)
            {
                //If slot is lower than minimum, resets to max amt
                currentSlot = transform.childCount - 1;
            }
            transform.GetChild(currentSlot).GetComponent<Image>().sprite = selSprite;
        }


        if (Input.GetMouseButtonDown(0))
        {
            //If left click
            if (inv.GetChild(currentSlot).childCount > 0)
            {
                //If the current slot isn't empty
                //Sets item use bool to true
                inv.GetChild(currentSlot).GetComponent<ItemSlot>().itemUse = true;
            }
        }
        
    }
}
