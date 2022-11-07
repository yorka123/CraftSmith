using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<bool> isFull = new List<bool>();
    public List<GameObject> slots = new List<GameObject>();
    public GameObject SlotManager;


    private void Start()
    {
        for (int i = 0; i < SlotManager.transform.childCount; i++) // childCount: 取得子物件數量
        {
            slots.Add(SlotManager.transform.GetChild(i).gameObject);
            isFull.Add(false);
        }
        // 添加isFull內bool數
    }
}
