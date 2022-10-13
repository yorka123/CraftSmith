using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem2 : MonoBehaviour
{
    [SerializeField]
    private Collider2D _collider2d;

    [SerializeField]
    private ContactFilter2D _contactFilter2d; // ContactFilter2D是什麼？

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            List<Collider2D> results = new List<Collider2D>(); // List<元素類型>名字 = new List
            if (Physics2D.OverlapCollider(_collider2d, _contactFilter2d, results) > 0) // OverlapCollider：計算碰撞重疊數量(maybe)
            {
                foreach (var collider2D in results) // var：在編譯期間被指派明確的類別(ex：現在是Collider2D)
                {
                    if (collider2D.CompareTag("Collectable"))
                    {
                        //撿起物品

                        Debug.Log("Collided!");
                    }
                }
            }
        }
    }
}
