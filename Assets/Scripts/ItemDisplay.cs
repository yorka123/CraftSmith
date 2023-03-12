using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;
    public Image icon;
    public GameObject ItemParent;

    #region 設置
    public void Setup(Item _item) //設定物件圖片到物品欄上的CrafingItem
    {
        item = _item;
        icon.sprite = item.icon;
        item.Selected = false;
    }
    #endregion

    #region 移除
    public void Unsetup()
    {
        item = null;
        icon.sprite = null;
        item.Selected = false;
    }
    #endregion

    #region 點擊觸發事件
    public void OnClickCraftingItem()
    {
        item.Selected = !item.Selected;
        if (item.Selected)
        {
            ItemParent.GetComponentInChildren<ItemDisplay>().item.Selected = false; // 設置其他物件的Selected為false
            Crafter.instance.SelectItem(item, gameObject);
        }
        else
        {
            Crafter.instance.SelectItem(null, null); 
        }

    }
    #endregion
}
