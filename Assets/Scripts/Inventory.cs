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
        for (int i = 0; i < SlotManager.transform.childCount; i++) // childCount: ���o�l����ƶq
        {
            slots.Add(SlotManager.transform.GetChild(i).gameObject); //�l�����J���~�椺
            isFull.Add(false);
        }
        // �K�[isFull��bool��
    }

    public void Add (Collider2D collider2D, Item item)
    {
        for (int i = 0; i < slots.Count; i++) // �̷Ӷ����˯��Ū��~��
        {
            if (isFull[i] == false)
            {
                isFull[i] = true;
                // ���~��J���~�椺

                Instantiate(collider2D, slots[i].transform);
                items.Add(item);

                break;
            }
        }
    }
}
