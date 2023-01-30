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

    Item addItem;
    int slotNum;

    public Recipe[] recipe;

    public Transform resultParent;
    public GameObject itemPrefeb;

    private void Start()
    {
        recipe = Resources.LoadAll<Recipe>("Recipe");
    }

    public void SetAddItem(Item item)
    {
        addItem= item;
        Debug.Log("That Works!");
    }

    public void SetSlotNum(int SlotNum)
    {
        slotNum = SlotNum;
        // Debug.Log("That Works! num:" + slotNum);
    }

}
