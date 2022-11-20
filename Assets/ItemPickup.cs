using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable // «Ýµ§¡GInteractable
{
    public Item item;
    
    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    void Pickup()
    {

    }

    bool CheckCollisions(Collider2D PCollider, Vector2 direction, float radious)
    {
        // if DID hit collider
        return true;
    }
}
