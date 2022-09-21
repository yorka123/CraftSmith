using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : MonoBehaviour
{
    public GameObject PickUI;

    private void Start()
    {
        PickUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PickUI.SetActive(false);
    }

    public void PickItem()
    {
        
        Debug.Log("PICKED");
        // 摧毀物件 然後放到類似物品欄的東西裡
    }
}
