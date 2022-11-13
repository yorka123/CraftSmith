using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem : MonoBehaviour
{

    private Inventory inventory;
    public Item item;

    [SerializeField] // [SerializeField]：將private/protected變量可序列化，下次讀取的值即為上次賦予的值
    private Collider2D _collider2d;

    [SerializeField]
    private ContactFilter2D _contactFilter2d; //  ContactFilter2D：可以自訂義的碰撞判定(控制面板在Unity)

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            List<Collider2D> results = new List<Collider2D>(); // 宣布一個List，型態為Collider2D；new list：建置新陣列(ex."results"為被創造出的新陣列)

                if (Physics2D.OverlapCollider(_collider2d, _contactFilter2d, results) > 0) // OverlapCollider(角色, 被撿取物, 重疊物數量)
                                                                                       // ex.一物 = 1，二物 = 2，無 = 0
                                                                                       // 是個函式啦 會獲得所有碰撞物的清單 回傳result內的碰撞物數量(int)
            {
                foreach (var collider2D in results) // var：在編譯期間被指派明確的類別(ex：現在是Collider2D)；foreach(~in results)：一項一項讀取
                {

                    if (collider2D.CompareTag("Collectable"))
                    {
                         Inventory.instance.Add(collider2D, item);
                         Destroy(collider2D.gameObject);
                    }
                }
            }
        }
    }
}
