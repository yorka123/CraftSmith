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

    public int space = 20;

    public bool Add(Item item)
    {
        if (items.Count < space) { 
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback(); // Invoke：就 執行 | 可簡化變成 委派名稱(參數群)
            
            return true;
        }

        Debug.Log("Not enough room.");
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
