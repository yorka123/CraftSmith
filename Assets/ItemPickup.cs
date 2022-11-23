using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable // �ݵ��GInteractable
{
    public Item item;
    
    public override void Interact() // �~�� Iteract()(Interactable)
    {
        base.Interact();
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("PICKEDUP");
        Inventory.Instance.Add(item);
        Destroy(gameObject);
    }

}
