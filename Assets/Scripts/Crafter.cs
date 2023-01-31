using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    #region Singleton

    public static Crafter instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Item slot1;
    public Item slot2;
    public Item slot3;
    // Display


    Item addItem;
    int slotNum;

    Recipe[] recipes;

    public Transform resultParent;
    public GameObject itemPrefeb;

    private void Start()
    {
        recipes = Resources.LoadAll<Recipe>("Recipe");
    }

    public void SetAddItem(Item item)
    {
        addItem= item;
        // Debug.Log("That Works!");
        UpdateCraftSlot();
    }

    public void SetSlotNum(int SlotNum)
    {
        slotNum = SlotNum;
        // Debug.Log("That Works! num:" + slotNum);
        UpdateCraftSlot();
    }

    public void UpdateCraftSlot()  // �C��SetAddItem / SetSlotNum����s�@��
    {
        if (addItem != null && slotNum != 0) // �p�GaddItem�MslotNum�����۹����Ѽ�
        {
            switch (slotNum)
            {
                case 1:
                    slot1 = addItem; break;
                case 2:
                    slot2 = addItem; break;
                case 3:
                    slot3 = addItem; break;
            }
        }
    }

    void CraftSlotDiaplay(GameObject slot) // ��sCraftSlot��image�Mitem
        //����
    {
        CraftSlot slotDisplay = slot.GetComponent<CraftSlot>();
        slotDisplay.image.sprite = addItem.icon;
    }

    Item[] GetResult() // �ͦ��X�����G
    {
        if (slot1 == null || slot2 == null || slot3 == null)
            return null;

        List<Item> result = new List<Item>();

        foreach (Recipe recipe in recipes)
        {
            // �P�_�O�_�ŦX����recipe
        }
        return result.ToArray();
    }

}
