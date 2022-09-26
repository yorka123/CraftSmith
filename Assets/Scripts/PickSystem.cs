using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            if (Input.GetButtonDown("Submit")) // F or Enter
            {
                Debug.Log("You have collected an item!");
                
                Destroy(collision.gameObject);
                // 然後放入物品欄之類的
            }
            // ERROR OnTriggerStay2D沒辦法持續偵測物件
        }
    }
}
