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

    public void SetAddItem(Item item)// TODO�G�b�z���ƫݥ[�JCraftSlot������A
                                     // �W�ӳQ���������^�_���(���F�Q����iCraftSlot�A�P�˳ƿ�z���ƪ������󤧥~)
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

    public void CreateItem() // ���ͦX����
    {
        Item[] Results = GetResult();
        
        if (Results.Length > 0) // �Y���X���X�F��
        {
            foreach (Item item in Results) // �[�J���~��
            {
                Inventory.Instance.items.Add(item);
            }
            //Inventory.Instance.RemoveItemFromInventory();
        }
    }

    void CraftSlotSetup(GameObject slot) //��CraftSlot��CraftSlotSetup�h�L��(���I��
    {
        CraftSlot Display = slot.GetComponent<CraftSlot>();
        Display.CraftSlotSetup(addItem);
        Inventory.Instance.Remove(addItem); // �M�����~��W����
    }

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

}
