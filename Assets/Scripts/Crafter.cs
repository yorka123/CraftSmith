using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Crafter : MonoBehaviour
{
    #region Singleton

    public static Crafter instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField] GameObject slot1;
    [SerializeField] GameObject slot2;
    [SerializeField] GameObject slot3;

    Item input1;
    Item input2;
    Item input3;

    Item addItem;
    int slotNum;

    Recipe[] recipes;

    public Transform resultParent;
    public GameObject itemPrefeb;

    private void Start()
    {
        recipes = Resources.LoadAll<Recipe>("Recipe");
    }

    public void SetAddItem(Item item)// TODO：半透明化待加入CraftSlot的物件，
                                     // 上個被選取的物件回復原樣(除了被選取進CraftSlot，同樣備辦透明化的的物件之外)
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

    public void UpdateCraftSlot()  // 每次SetAddItem / SetSlotNum都更新一次
    {
        if (addItem != null && slotNum != 0) // 如果addItem和slotNum都有相對應參數
        {
            switch (slotNum)
            {
                case 1:
                    input1 = addItem;
                    CraftSlotSetup(slot1); break;
                case 2:
                    input2 = addItem;
                    CraftSlotSetup(slot2); break;
                case 3:
                    input3 = addItem;
                    CraftSlotSetup(slot3); break;
            }
        }
    }

    public void CreateItem() // 產生合成物
    {
        Item[] Results = GetResult();
        
        if (Results.Length > 0) // 若有合成出東西
        {
            foreach (Item item in Results) // 加入物品欄
            {
                Inventory.Instance.items.Add(item);
            }
            //Inventory.Instance.RemoveItemFromInventory();
        }
    }

    void CraftSlotSetup(GameObject slot) //把CraftSlot的CraftSlotSetup搬過來(有點醜
    {
        CraftSlot Display = slot.GetComponent<CraftSlot>();
        Display.CraftSlotSetup(addItem);
        Inventory.Instance.Remove(addItem); // 清除物品欄上物件
    }

    Item[] GetResult() // 生成合成結果
    {
        if (input1 == null || input2 == null || input3 == null) //如果有合成欄位空著
            return null;

        List<Item> results = new List<Item>();

        foreach (Recipe recipe in recipes) // 跑過整個recipe
        {
            if (recipe.item1 == input1 || recipe.item2 == input2 || recipe.item3 == input3) {
                results.Add(recipe.Result); // ver1.0：固定配方
            }
        }
        return results.ToArray();
    }

}
