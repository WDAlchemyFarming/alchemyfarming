using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private Transform inv;
    private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").transform;
        item = transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform firstSlot = null;
            Transform addSlot = null;
            for (int i = 0; i < inv.childCount; i++){
                if (inv.GetChild(i).childCount == 0 && firstSlot == null)
                {
                    firstSlot = inv.GetChild(i);
                }
                if (inv.GetChild(i).GetComponent<ItemSlot>().title == transform.GetChild(0).GetComponent<ItemSlot>().title && addSlot == null)
                {
                    addSlot = inv.GetChild(i);
                }
            }
            if (addSlot != null)
            {
                addSlot.GetComponent<ItemSlot>().addQuant++;
            } else if (firstSlot != null)
            {
                Instantiate(item, firstSlot);
            }
            if (addSlot != null || firstSlot != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
