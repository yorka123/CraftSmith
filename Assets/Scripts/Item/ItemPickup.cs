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
        if (Input.GetButtonDown("Submit"))
        {
            bool wasInterected = Inventory.Instance.Add(item);
            if (wasInterected)
            {
                Debug.Log("Picking up " + item.name);
                Destroy(gameObject);
            }
        }


    }

}
