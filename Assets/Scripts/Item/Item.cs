using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // �ǦC�� ��� ���O
public class Data
{
    public string name = "New Item";
    public Sprite icon = null;
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)] // �b�ɮ����O���i�˵�,(fileName = �ͦ�����W, menuName = ���|, oreder = ����)
public class Item : ScriptableObject //�귽�ɫŧi
{
    
    public Data data;
}
