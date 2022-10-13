using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem : MonoBehaviour
{
    bool Pick = false;
    GameObject PickObject; // 被撿取物件

    private void Update()
    {
        if (Input.GetButtonDown("Submit")) // F or Enter
        {
            Pick = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            if (Input.GetButtonDown("Submit")) // F or Enter
            {
                PickObject = collision.gameObject;
                Pick = true; // 改：為了讓判定不會被重置(但好像沒用)
                // ERROR 現在變成在範圍中偶爾判定一次成功
            }

        }
    }

    private void FixedUpdate()
    {
        if (Pick)
        {
            Debug.Log("You have collected an item!");
            
            Destroy(PickObject);
            
            Pick = false;
            // 然後放入物品欄之類的
        }
    }
}
