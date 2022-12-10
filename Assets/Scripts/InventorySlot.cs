using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.data.icon;   
        icon.enabled = true;
        removeButton.interactable= true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void UseItem()
    {
        item.Use();
    }

    public void OnRemoveButton()
    {
        Debug.Log("Removing " + item.name);
        Inventory.Instance.Remove(item);
    }

}
