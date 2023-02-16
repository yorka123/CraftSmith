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

    GameObject addItem;
    int slotNum;

    Recipe[] recipes;

    public Transform resultParent;
    public GameObject itemPrefeb;

    private void Start()
    {
        recipes = Resources.LoadAll<Recipe>("Recipe");
    }

    #region SetItem&SlotNum �]�m���~+���s��
    public void SelectItem(GameObject SelectedItem)// OnClick CraftingItem����N��GameObject��iaddItem
     
    {
        addItem = SelectedItem;
        // Debug.Log("That Works!");
        UpdateCraftSlot();
    }

    public void SetSlotNum(int SlotNum)
    {
        slotNum = SlotNum;
        // Debug.Log("That Works! num:" + slotNum);
        UpdateCraftSlot();
    }
    #endregion

    #region UpdateSlot ��s���
    public void UpdateCraftSlot()  // �C��SetAddItem / SetSlotNum����s�@��
    {
        if (addItem != null && slotNum != 0) // �p�GaddItem�MslotNum�����۹����Ѽ�
        {
            switch (slotNum)
            {
                case 1:
                    input1 = addItem.GetComponent<ItemDisplay>().item;
                    CraftSlotSetup(slot1); break;
                case 2:
                    input2 = addItem.GetComponent<ItemDisplay>().item;
                    CraftSlotSetup(slot2); break;
                case 3:
                    input3 = addItem.GetComponent<ItemDisplay>().item;
                    CraftSlotSetup(slot3); break;
            }
        }
    }
    #endregion

    #region CreateItem �ͦ��X����

    public void CreateItem() // ���ͦX����
    {
        Item[] Results = GetResult(); // �X�����G
        
        if (Results.Length > 0) // �Y���X���X�F��
        {
            foreach (Item item in Results) // �[�J���~��
            {
                Inventory.Instance.items.Add(item);
            }
            //Inventory.Instance.RemoveItemFromInventory();
        }
    }
    #endregion

    #region SlotSetup ��ܦX���Ϊ��~

    void CraftSlotSetup(GameObject slot)
    {
        
        GameObject CraftItem = Instantiate(addItem, slot.transform);
        ItemDisplay display = CraftItem.GetComponent<ItemDisplay>();
        display.Setup(addItem.GetComponent<ItemDisplay>().item);

        Inventory.Instance.Remove(addItem.GetComponent<ItemDisplay>().item); // �M�����~��W����
    }
    #endregion

    #region ifRecipe �t��P�_

    Item[] GetResult() // �ͦ��X�����G
    {
        if (input1 == null || input2 == null || input3 == null) //�p�G���X�����ŵ�
            return null;

        List<Item> results = new List<Item>();

        foreach (Recipe recipe in recipes) // �]�L���recipe
        {
            if (recipe.item1 == input1 || recipe.item2 == input2 || recipe.item3 == input3) {
                results.Add(recipe.Result); // ver1.0�G�T�w�t��
            }
        }
        return results.ToArray();
    }
    #endregion

}
