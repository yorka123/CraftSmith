using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 序列化 資料 類別
public class Data
{
    public string name = "New Item";
    public Sprite icon = null;
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)] // 在檔案類別中可檢視,(fileName = 生成物件名, menuName = 路徑, oreder = 順序)
public class Item : ScriptableObject //資源檔宣告
{
    
    public Data data;
}
