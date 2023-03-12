using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;
    public Image icon;
    public GameObject ItemParent;

    #region �]�m
    public void Setup(Item _item) //�]�w����Ϥ��쪫�~��W��CrafingItem
    {
        item = _item;
        icon.sprite = item.icon;
        item.Selected = false;
    }
    #endregion

    #region ����
    public void Unsetup()
    {
        item = null;
        icon.sprite = null;
        item.Selected = false;
    }
    #endregion

    #region �I��Ĳ�o�ƥ�
    public void OnClickCraftingItem()
    {
        item.Selected = !item.Selected;
        if (item.Selected)
        {
            ItemParent.GetComponentInChildren<ItemDisplay>().item.Selected = false; // �]�m��L����Selected��false
            Crafter.instance.SelectItem(item, gameObject);
        }
        else
        {
            Crafter.instance.SelectItem(null, null); 
        }

    }
    #endregion
}
