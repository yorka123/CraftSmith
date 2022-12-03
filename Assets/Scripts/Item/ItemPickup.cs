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
        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("Picked");
            bool wasInterected = Inventory.Instance.Add(item);
            if (wasInterected)
            {
                Destroy(gameObject);
            }
        }


    }

}
