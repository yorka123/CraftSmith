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
    public int slotNum;

    public void OnClickCraftSlot()
    {
        Crafter.instance.SetSlotNum(slotNum);
    }
}
