using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)] // 在檔案類別中可檢視,(fileName = 生成物件名, menuName = 路徑, oreder = 順序)
public class Item : ScriptableObject //資源檔宣告
{

    public Sprite icon;
    public bool Selected;

    public virtual void Use()
    {
        // Use the item
        // Somthing will happen

        Debug.Log("Using " + name);
    }

}
