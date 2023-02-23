using UnityEngine;

public class Collectable : Interactable // �ݵ��GInteractable
{
    public Item item;
    public Sprite icon;
    
    public override void Interact() // �~�� Iteract()(Interactable)
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Inventory.Instance.AddItemIntoInventory(item);

            Debug.Log("Picking up " + item.name);
            Destroy(gameObject);
        }
    }

    void iconSetup()
    {
        icon = item.icon;
    }

}


