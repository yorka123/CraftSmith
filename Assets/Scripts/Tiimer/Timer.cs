using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public bool timerActive = false;
    float currentTime;
    public int StartTime = 60;

    public Text currentTimeText;

    void Start()
    {
        timerActive= true;
        currentTime= StartTime;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;

            if(currentTime <= 0)
            {
                timerActive = false;
                Debug.Log("Timer finished!");
                CraftMenu.instance.MenuOpen();
            }
        }
        
        TimeSpan time = TimeSpan.FromSeconds(currentTime); //TimeSpan.FromSeconds(Value)：六十進位化
        currentTimeText.text = time.Seconds.ToString();
    }



}
