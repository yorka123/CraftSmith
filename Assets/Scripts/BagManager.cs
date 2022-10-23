using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{

    public BagUnit m_CloneUnit = null;
    public Transform m_BagNode = null;

    public Sprite[] mTotalItemSprite = null;

    private void Awake()
    {

    }

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            ItemData id = new ItemData();
            id.m_Count = 1;
            BagUnit unit = Instantiate<BagUnit>(m_CloneUnit, m_BagNode);
            // Instantiate：生成預製(Prefeb)物件
            // Instantiate<使用函式？>(要生成的物件, 位置) [?]

        }
    }


}