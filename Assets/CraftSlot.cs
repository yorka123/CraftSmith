using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    #region Singleton

    public static CraftSlot instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Item item;
    public Image image;
    public int slotNum;

    public void OnClickCraftSlot()
    {
        Crafter.instance.SetSlotNum(slotNum);
    }

    public void CraftSlotSetup(Item _item) //�]�w����Ϥ���CraftSlot�W
    {
        // Debug.Log(slotNum);
        item = _item; 
        image.sprite = item.icon;
    }
}
