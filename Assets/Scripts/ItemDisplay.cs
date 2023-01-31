using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;
    public Image icon;

    public void SetUp(Item _item) //�]�w����Ϥ��쪫�~��W��CrafingItem
    {
        item = _item;
        icon.sprite = item.icon;
    }

    public void OnClickCraftingItem()
    {
        Crafter.instance.SetAddItem(item);
        // Debug.Log("It works! The added item is" + item);
    }

}
