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

    Item SelectedItem;
    int index;

    Recipe[] recipes;

    public Transform resultParent;
    public GameObject itemPrefeb;

    private void Start()
    {
        recipes = Resources.LoadAll<Recipe>("Recipe");
    }

    #region SetItem&SlotNum 設置物品+欄位編號
    public void SelectItem(Item selectedItem)// OnClick CraftingItem之後將其GameObject抓進addItem
     
    {
        SelectedItem = selectedItem;
        UpdateCraftSlot();
    }

    public void SetSlotNum(int SlotNum)
    {
        index = SlotNum;
        UpdateCraftSlot();
    }
    #endregion

    #region UpdateSlot 更新欄位
    public void UpdateCraftSlot()  // 每次SetAddItem / SetSlotNum都更新一次
    {
        if (SelectedItem != null && index != 0) // 如果addItem和slotNum都有相對應參數
        {
            switch (index)
            {
                case 1:
                    input1 = SelectedItem;
                    CraftSlotSetup(slot1); break;
                case 2:
                    input2 = SelectedItem;
                    CraftSlotSetup(slot2); break;
                case 3:
                    input3 = SelectedItem;
                    CraftSlotSetup(slot3); break;
            }
        }
    }
    #endregion

    #region CreateItem 生成合成物

    public void CreateItem() // 產生合成物
    {
        Item[] Results = GetResult(); // 合成結果
        
        if (Results != null) // 若有合成出東西
        {
            foreach (Item item in Results) // 加入物品欄
            {
                Inventory.Instance.items.Add(item);
            }
            Inventory.Instance.Remove(input1);
            Inventory.Instance.items.Remove(input2);
            Inventory.Instance.items.Remove(input3); // 移除被用作合成的道具
        }
    }
    #endregion

    #region SlotSetup 顯示合成用物品

    void CraftSlotSetup(GameObject slot)
    {
        ItemDisplay display = slot.GetComponent<ItemDisplay>();
        display.Setup(SelectedItem);
    }
    #endregion

    #region ifRecipe 配方判斷

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
    #endregion

}
// 改：用bool設置物品，當選擇slot/item時始被選擇的其bool selected = true，並UpdateSelection()