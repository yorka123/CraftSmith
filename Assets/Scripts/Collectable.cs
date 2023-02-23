using UnityEngine;

public class Collectable : Interactable // «Ýµ§¡GInteractable
{
    public Item item;
    public SpriteRenderer icon;

    private void Awake()
    {
        iconSetup();
    }

    public override void Interact() // Ä~©Ó Iteract()(Interactable)
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
        icon.sprite = item.icon;
    }

}


