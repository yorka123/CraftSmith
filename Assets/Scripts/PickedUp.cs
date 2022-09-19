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

    public void PickUITrigger()
    {
      PickUI.SetActive(true);
    }

    public void PickItem()
    {
        Debug.Log("PICKED");
        // 摧毀物件 然後放到類似物品欄的東西裡
    }
}
