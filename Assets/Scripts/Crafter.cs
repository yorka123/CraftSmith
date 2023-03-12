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

    [SerializeField] GameObject slot1;
    [SerializeField] GameObject slot2;
    [SerializeField] GameObject slot3;

    Item input1;
    Item input2;
    Item input3;

    Item SelectedItem;
    GameObject SelectedObject;
    GameObject OldItem;
    int index;

    Recipe[] recipes;

    public Transform resultParent;
    public GameObject itemPrefeb;

    private void Start()
    {
        recipes = Resources.LoadAll<Recipe>("Recipe");
    }

    #region SetItem&SlotNum �]�m���~+���s��
    public void SelectItem(Item selectedItem, GameObject selectedObject)// OnClick CraftingItem����N��GameObject��iaddItem
     
    {
        SelectedItem = selectedItem;
        SelectedObject= selectedObject;
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
                    CraftSlotSetup(slot1);
                    OldItem = Instantiate(SelectedObject);
                    Destroy(SelectedObject); 
                    Instantiate(OldItem, Inventory.Instance.itemPool); break;
                case 2:
                    input2 = SelectedItem;
                    CraftSlotSetup(slot2);
                    OldItem = Instantiate(SelectedObject);
                    Destroy(SelectedObject);
                    Instantiate(OldItem, Inventory.Instance.itemPool); break;
                case 3:
                    input3 = SelectedItem;
                    CraftSlotSetup(slot3);
                    OldItem = Instantiate(SelectedObject);
                    Destroy(SelectedObject);
                    Instantiate(OldItem, Inventory.Instance.itemPool); break;                       
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
                Debug.Log(item + "created");
                Inventory.Instance.AddItemIntoInventory(item);
            }

            Debug.Log("Items been removed:" + input1+input2+input3);

            CraftSlotUnsetup(slot1);
            CraftSlotUnsetup(slot2);
            CraftSlotUnsetup(slot3);

            Inventory.Instance.Remove(input1);
            Inventory.Instance.items.Remove(input2);
            Inventory.Instance.items.Remove(input3); // �����Q�Χ@�X�����D��
        }
    }
    #endregion

    #region SlotSetup �X���Ϊ���]�m

    void CraftSlotSetup(GameObject slot)
    {
        ItemDisplay display = slot.GetComponent<ItemDisplay>();
        display.Setup(SelectedItem);
    }
    #endregion

    #region �X���Ϊ��󲾰�

    void CraftSlotUnsetup(GameObject slot)
    {
        ItemDisplay display = slot.GetComponent<ItemDisplay>();
        display.Unsetup();
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