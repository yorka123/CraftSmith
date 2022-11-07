using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject SlotManager;


    private void Start()
    {
        for (int i = 0; i < SlotManager.transform.childCount; i++) // childCount: 取得子物件數量
        {
            slots[i] = SlotManager.transform.GetChild(i).gameObject;
        }
        // 添加isFull內bool數
    }
}
