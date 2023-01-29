using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        // 取得物品欄的Compoments
    }

    private void UpdateUI() //原：逐一更新所有slots，依據items的數量，使其顯示/刪除slots內物件
    {


    }    
}
