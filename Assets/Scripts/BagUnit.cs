using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUnit : MonoBehaviour
{

    public Image m_Icon = null;
    public Text m_CountText = null;
    public Text m_EquipText = null;

    public ItemData m_TempData = null;

    public void Refresh(ItemData itemData)
    {
        if (itemData == null)
        {
            m_Icon.sprite = null;
            m_CountText = null;
            m_EquipText = null;
            return;
        }

        m_TempData = itemData;
        m_Icon.sprite = itemData.Icon;
        m_CountText.text = itemData.m_Count.ToString();
        m_EquipText.text = "";
    }

    public void OnEquip(bool equip)
    {
        m_TempData.m_Equip = equip;
        RefreshEquip();

    }

    public void RefreshEquip()
    {
        if (m_TempData.m_Equip)
            m_EquipText.text = "¸Ë³Æ¤¤";
        else
            m_EquipText.text = "";
    }
}