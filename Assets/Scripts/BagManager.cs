using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BagManager : MonoBehaviour
{

    public BagUnit m_CloneUnit = null;
    public Transform m_BagNode = null;
    public BagUnit m_LeftUnit = null;
    public BagUnit m_RightUnit = null; // 左右手

    public Sprite[] mTotalItemSprite = null;

    public List<ItemData> mTotalItemData = new List<ItemData> ();
    public List<BagUnit> mTotalItemBagUnit = new List<BagUnit> ();

    public bool m_isLeft = false;

    private void Awake()
    {

        m_LeftUnit.Refresh(null);
        m_RightUnit.Refresh(null);

    }

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            ItemData id = new ItemData();
            int r  = Random.Range(0,mTotalItemSprite.Length); // Random.range(min, max)
            Sprite s = mTotalItemSprite[r];
            id.m_Count = 1;
            id.Icon = s;
            id.m_ID = r;
            mTotalItemData.Add(id);

        }

        mTotalItemData.Sort(SortItem);

        for (int i = 0; i < mTotalItemData.Count; i++)
        {
            BagUnit unit = Instantiate<BagUnit>(m_CloneUnit, m_BagNode);
            // Instantiate：生成預製(Prefeb)物件
            // Instantiate<使用函式？>(要生成的物件, 位置)
            unit.Refresh(mTotalItemData[i]);
            mTotalItemBagUnit.Add(unit);
        }

    }

    public void RefreshList()
    {
        for (int i = 0; i < mTotalItemBagUnit.Count; i++)
        {
            mTotalItemBagUnit[i].Refresh(null);
        }
    }

    public int SortItem(object a,object b)
    {
        ItemData i1 = a as ItemData;
        ItemData i2 = b as ItemData;

        if (i1.m_ID > i2.m_ID)
        {
            return 1;
        }
        else if (i1.m_ID < i2.m_ID)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public void OnClickUnit(BagUnit unit)
    {
        unit.OnEquip(true);
        if (m_isLeft)
        {
            if (m_LeftUnit != null)
                m_LeftUnit.OnEquip(false);

            m_LeftUnit.Refresh(unit.m_TempData);
        }
        else
        {
            if (m_RightUnit != null)
                m_RightUnit.OnEquip(false);

            m_RightUnit.Refresh(unit.m_TempData);
        }
        RefreshList();
    }

    public void OnClickLeft()
    {
        m_isLeft = true;
    }

    public void OnClickRight()
    {
        m_isLeft = false;
    }
}