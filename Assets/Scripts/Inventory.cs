using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance; // static(靜態)： 使所有 Instance(實例) 皆共享Inventory(class)

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }

        Instance = this;
    }
    #endregion
    //region-endregion：收納程式碼(使可疊合)
    
    public delegate void OnItemChanged(); // delagate：(method)委託，用於執行事件清單
    public OnItemChanged onItemChangedCallback; // 更新UI用

    public List<Item> items = new List<Item>();

    public GameObject itemPrefeb;
    public Transform itemPool;

    public void AddItemIntoInventory(Item item) // 將物件加入物品欄內
    {
        items.Add(item); // 加入物品攔

        GameObject itemObj = Instantiate(itemPrefeb, itemPool);
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
        if (display != null) {
            display.Setup(item);
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback(); // Invoke：執行 | 可簡化變成 委派名稱(參數群)
    }

    public void RemoveItemFromInventory(Item item) // TODO：合成成功後刪除Inventory內的三個GhostItem
    {

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
