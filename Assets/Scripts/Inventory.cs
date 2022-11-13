using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<bool> isFull = new List<bool>();
    public List<GameObject> slots = new List<GameObject>();
    public GameObject SlotManager;

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    private void Start()
    {
        for (int i = 0; i < SlotManager.transform.childCount; i++) // childCount: 取得子物件數量
        {
            slots.Add(SlotManager.transform.GetChild(i).gameObject); //子物件放入物品欄內
            isFull.Add(false);
        }
        // 添加isFull內bool數
    }

    public void Add (Collider2D collider2D, Item item)
    {
        for (int i = 0; i < slots.Count; i++) // 依照順序檢索空物品欄
        {
            if (isFull[i] == false)
            {
                isFull[i] = true;
                // 物品放入物品欄內

                Instantiate(collider2D, slots[i].transform);
                items.Add(item);

                break;
            }
        }
    }
}
