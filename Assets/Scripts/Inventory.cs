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

    #region 物件加入物品欄

    public void AddItemIntoInventory(Item item)
    {
        items.Add(item); // 加入物品攔

        GameObject itemObj = Instantiate(itemPrefeb, itemPool);
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
        if (display != null) {
            display.Setup(item);
            display.ItemParent = itemPool.gameObject; // 抓CraftingItem的母物件
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback(); // Invoke：執行 | 可簡化變成 委派名稱(參數群)
    }
    #endregion

    #region 物件至物品欄移除

    public void Remove(Item item)
    {
        items.Remove(item);

        Debug.Log(items.Contains(item));

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
    #endregion
}
