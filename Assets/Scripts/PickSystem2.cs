using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem大神範例 : MonoBehaviour
{
    [SerializeField] // [SerializeField]：將private/protected變量可序列化，下次讀取的值即為上次賦予的值
    private Collider2D _collider2d;

    [SerializeField]
    private ContactFilter2D _contactFilter2d; //  ContactFilter2D：可以自訂義的碰撞判定(控制面板在Unity)

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            List<Collider2D> results = new List<Collider2D>(); // 宣布一個List，型態為Collider2D；new list：建置新陣列(ex."results"為被創造出的新陣列)
            
            if (Physics2D.OverlapCollider(_collider2d, _contactFilter2d, results) > 0) // OverlapCollider(被撿取物, 角色, 重疊數量(回傳的值從results來))
            {
                foreach (var collider2D in results) // var：在編譯期間被指派明確的類別(ex：現在是Collider2D)；foreach(~in results)：一項一項讀取
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
