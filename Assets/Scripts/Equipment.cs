using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment", order = 2)]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int DamageModifier;

    public override void Use()
    {
        base.Use();
        EquipManager.instance.Equip(this);
    }

}

public enum EquipmentSlot { Accessory, Weapon }
