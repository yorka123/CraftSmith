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

    #region SetItem&SlotNum �]�m���~+���s��
    public void SelectItem(Item selectedItem)// OnClick CraftingItem����N��GameObject��iaddItem
     
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

    #region UpdateSlot ��s���
    public void UpdateCraftSlot()  // �C��SetAddItem / SetSlotNum����s�@��
    {
        if (SelectedItem != null && index != 0) // �p�GaddItem�MslotNum�����۹����Ѽ�
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

    #region CreateItem �ͦ��X����

    public void CreateItem() // ���ͦX����
    {
        Item[] Results = GetResult(); // �X�����G
        
        if (Results != null) // �Y���X���X�F��
        {
            foreach (Item item in Results) // �[�J���~��
            {
                Inventory.Instance.items.Add(item);
            }
            Inventory.Instance.Remove(input1);
            Inventory.Instance.items.Remove(input2);
            Inventory.Instance.items.Remove(input3); // �����Q�Χ@�X�����D��
        }
    }
    #endregion

    #region SlotSetup ��ܦX���Ϊ��~

    void CraftSlotSetup(GameObject slot)
    {
        ItemDisplay display = slot.GetComponent<ItemDisplay>();
        display.Setup(SelectedItem);
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
// ��G��bool�]�m���~�A����slot/item�ɩl�Q��ܪ���bool selected = true�A��UpdateSelection()