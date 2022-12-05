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

    public int space = 20;

    public bool Add(Item item)
    {
        if (items.Count < space) { 
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback(); // Invoke�G�N ���� | �i²���ܦ� �e���W��(�ѼƸs)
            
            return true;
        }

        Debug.Log("Not enough room.");
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
