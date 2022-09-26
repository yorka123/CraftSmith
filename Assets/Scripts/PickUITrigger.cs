using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUITrigger : MonoBehaviour
{
    public GameObject PickUI;

    private void Start()
    {
        PickUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUI.SetActive(true);
            // 顯示提示欄
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUI.SetActive(false);
        }
    }
}
