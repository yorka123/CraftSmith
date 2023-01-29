using UnityEngine;

public class ItemPickup : Interactable // �ݵ��GInteractable
{
    public Item item;
    
    public override void Interact() // �~�� Iteract()(Interactable)
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Inventory.Instance.AddItem(item);

            Debug.Log("Picking up " + item.name);
            Destroy(gameObject);
        }


    }

}
