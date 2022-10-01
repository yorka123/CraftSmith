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
            List<Collider2D> results = new List<Collider2D>(); // 宣布一個List，型態為Collider2D
            if (Physics2D.OverlapCollider(_collider2d, _contactFilter2d, results) > 0) // OverlapCollider又是啥？？
            {
                foreach (var collider2D in results) // var：在編譯期間被指派明確的類別(ex：現在是Collider2D)
                {
                    if (collider2D.CompareTag("Collectable"))
                    {
                        //撿起物品

                        Destroy(collider2D.gameObject);
                    }
                }
            }
        }
    }
}
