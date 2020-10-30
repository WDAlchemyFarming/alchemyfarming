using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool taken;
    public Sprite empty;
    private Transform inv;
    private Transform mh;
    private int index;

    //This script is used in the item slots of the UI inventory menu

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").transform;
        mh = GameObject.Find("MouseHolder").transform;
        index = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        if (inv.GetChild(index) != null)
        {
            if (inv.GetChild(index).childCount > 0 || taken)
            {

                transform.GetChild(0).GetComponent<Image>().sprite = inv.GetChild(index).GetComponent<ItemSlot>().icon;
                taken = true;
            } else if (transform.GetChild(0).GetComponent<Image>().sprite != empty || !taken)
            {
                transform.GetChild(0).GetComponent<Image>().sprite = empty;
                taken = false;
            }
            if (inv.GetChild(index).childCount == 0)
            {
                taken = false;
            }
        }
    }

    public void OnClick()
    {
        if (taken && mh.childCount == 0)
        {
            inv.GetChild(index).GetChild(0).SetParent(mh);
            taken = false;
        } else if (!taken && mh.childCount > 0)
        {
            mh.GetChild(0).SetParent(inv.GetChild(index));
            taken = true;
        }
    }
}
