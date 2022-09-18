using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HausTrigger : MonoBehaviour
{

    public GameObject HausO;
    public SpriteRenderer HausORend;

    private Color HausOColor;
    public float FadeSpeed = 0.05f;
    private float CurrentFade; // 紀錄當前透明程度 癥結點: 1.CurrentFade怎麼紀錄？ 2.進出無法立即切換漸出漸入

    void Start()
    {
        HausOColor = HausORend.color; // 設定屋子顏色
        CurrentFade = HausORend.color.a;
}

    void OnTriggerEnter2D(Collider2D collision) // 入房屋 隱藏外觀 顯示內部 
    {
        if (collision.tag == "Player")
        {
            CurrentFade = HausORend.color.a / 255;
            StartCoroutine("FadeOut"); // StartCoroutine: IE招喚方式
            // Fade out
        }
    }

    void OnTriggerExit2D(Collider2D collision) // 出房屋 變回外觀
    {
        if (collision.tag == "Player")
        {
            CurrentFade = HausORend.color.a / 255;
            Debug.Log(CurrentFade);
            StartCoroutine("FadeIn");
            // Fade in
        }    
    }

    IEnumerator FadeOut() // IEnumerator:執行一次 大概  yield:IE的回傳方式 不會看阿空
    {
        Debug.Log("ＩＮ");

        for (float f = CurrentFade; f>= 0; f -= FadeSpeed)
        {
            HausOColor = HausORend.material.color;
            HausOColor.a = f;
            HausORend.material.color = HausOColor;

            yield return new WaitForFixedUpdate(); // PS:為什麼要new?
        }
    }

    IEnumerator FadeIn()
    {
        Debug.Log("ＯＵＴ");

        for (float f = CurrentFade; f <= 1; f += FadeSpeed)
        {
            HausOColor = HausORend.material.color;
            HausOColor.a = f;
            HausORend.material.color = HausOColor;

            yield return new WaitForFixedUpdate(); // ERROR 瞬間顯示 沒有漸入
        }
    }

}
