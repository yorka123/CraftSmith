using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)] // �b�ɮ����O���i�˵�,(fileName = �ͦ�����W, menuName = ���|, oreder = ����)
public class Item : ScriptableObject //�귽�ɫŧi
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
