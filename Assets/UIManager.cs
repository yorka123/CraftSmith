using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region Singleton
    public static UIManager Instance; // static(�R�A)�G �ϩҦ� Instance(���) �Ҧ@��Inventory(class)

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
        Time.timeScale = 1.0f; // timeScale�G�ɶ����v
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

}
