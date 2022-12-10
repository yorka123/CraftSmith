using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; // 查 Transform

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 
        // 取得物品欄的Compoments
    }

    private void UpdateUI()
    {
        for (int i = 0;i< slots.Length;i++)
        {
            if (i <inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
