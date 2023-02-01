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

    public void AddItemIntoInventory(Item item) // �N����[�J���~�椺
    {
        items.Add(item); // �[�J���~�d

        GameObject itemObj = Instantiate(itemPrefeb, itemPool);
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
        if (display != null) {
            display.Setup(item);
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback(); // Invoke�G���� | �i²���ܦ� �e���W��(�ѼƸs)
    }

    public void RemoveItemFromInventory(Item item) // TODO�G�X�����\��R��Inventory�����T��GhostItem
    {

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
