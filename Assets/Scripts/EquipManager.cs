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

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment olditem);
    public OnEquipmentChanged onEquipmentChanged;

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
            inventory.AddItem(oldItem);
        } // 舊物品放回Inventory上

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged(oldItem, newItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetButton("Unequip"))
        {
            UnequipAll();
        }
    }

}
