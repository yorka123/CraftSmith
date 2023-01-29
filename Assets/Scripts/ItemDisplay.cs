using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;
    public Image icon;

    public void SetUp(Item _item) //¨ú¥NDisplayItem
    {
        item = _item;
        Debug.Log(item);
        icon.sprite = item.icon;
    }

}
