using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region Singleton
    public static UIManager Instance; // static(靜態)： 使所有 Instance(實例) 皆共享Inventory(class)

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }

        Instance = this;
    }
    #endregion

    public void Resume()
    {
        Time.timeScale = 1.0f; // timeScale：時間倍率
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

}
