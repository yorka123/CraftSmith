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

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

}
