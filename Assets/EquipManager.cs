using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    #region Singleton
    public static EquipManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        // Enum.GetNames(typeof(enum))：回傳enum(EquipmentSlots)內的所有值
        currentEquipment= new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot; // later
  
        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem= currentEquipment[slotIndex];
            inventory.Add(oldItem);
        } // 舊物品放回Inventory上

        currentEquipment[slotIndex] = newItem;
    }

}
