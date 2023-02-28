using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance; // static(�R�A)�G �ϩҦ� Instance(���) �Ҧ@��Inventory(class)

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }

        Instance = this;
    }
    #endregion
    //region-endregion�G���ǵ{���X(�ϥi�|�X)
    
    public delegate void OnItemChanged(); // delagate�G(method)�e�U�A�Ω����ƥ�M��
    public OnItemChanged onItemChangedCallback; // ��sUI��

    public List<Item> items = new List<Item>();

    public GameObject itemPrefeb;
    public Transform itemPool;

    #region ����[�J���~��

    public void AddItemIntoInventory(Item item)
    {
        items.Add(item); // �[�J���~�d

        GameObject itemObj = Instantiate(itemPrefeb, itemPool);
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
        if (display != null) {
            display.Setup(item);
            display.ItemParent = itemPool.gameObject; // ��CraftingItem��������
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback(); // Invoke�G���� | �i²���ܦ� �e���W��(�ѼƸs)
    }
    #endregion

    #region ����ܪ��~�沾��

    public void Remove(Item item)
    {
        items.Remove(item);

        Debug.Log(items.Contains(item));

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
    #endregion
}
