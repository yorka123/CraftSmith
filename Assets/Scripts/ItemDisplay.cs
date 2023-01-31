using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;
    public Image icon;

    public void SetUp(Item _item) //設定物件圖片到物品欄上的CrafingItem
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
