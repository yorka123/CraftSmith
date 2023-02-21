using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;
    public Image icon;

    public void Setup(Item _item) //設定物件圖片到物品欄上的CrafingItem
    {
        item = _item;
        icon.sprite = item.icon;
    }

    public void OnClickCraftingItem()
    {
        item.Selected = !item.Selected;
        if (item.Selected) Crafter.instance.SelectItem(item);
        else Crafter.instance.SelectItem(null);
    }

}
