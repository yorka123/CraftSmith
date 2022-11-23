using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable // «Ýµ§¡GInteractable
{
    public Item item;
    
    public override void Interact() // Ä~©Ó Iteract()(Interactable)
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
