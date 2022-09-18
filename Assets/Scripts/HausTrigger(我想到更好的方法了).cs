using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HausTrigger : MonoBehaviour
{

    public GameObject HausO;
    public SpriteRenderer HausORend;

    private Color HausOColor;
    public float FadeSpeed = 0.05f;
    private float CurrentFade; // ������e�z���{�� �p���I: 1.CurrentFade�������H 2.�i�X�L�k�ߧY�������X���J

    void Start()
    {
        HausOColor = HausORend.color; // �]�w�Τl�C��
        CurrentFade = HausORend.color.a;
}

    void OnTriggerEnter2D(Collider2D collision) // �J�Ы� ���å~�[ ��ܤ��� 
    {
        if (collision.tag == "Player")
        {
            CurrentFade = HausORend.color.a / 255;
            StartCoroutine("FadeOut"); // StartCoroutine: IE�۳�覡
            // Fade out
        }
    }

    void OnTriggerExit2D(Collider2D collision) // �X�Ы� �ܦ^�~�[
    {
        if (collision.tag == "Player")
        {
            CurrentFade = HausORend.color.a / 255;
            Debug.Log(CurrentFade);
            StartCoroutine("FadeIn");
            // Fade in
        }    
    }

    IEnumerator FadeOut() // IEnumerator:����@�� �j��  yield:IE���^�Ǥ覡 ���|�ݪ���
    {
        Debug.Log("�ע�");

        for (float f = CurrentFade; f>= 0; f -= FadeSpeed)
        {
            HausOColor = HausORend.material.color;
            HausOColor.a = f;
            HausORend.material.color = HausOColor;

            yield return new WaitForFixedUpdate(); // PS:������nnew?
        }
    }

    IEnumerator FadeIn()
    {
        Debug.Log("�ݢ��");

        for (float f = CurrentFade; f <= 1; f += FadeSpeed)
        {
            HausOColor = HausORend.material.color;
            HausOColor.a = f;
            HausORend.material.color = HausOColor;

            yield return new WaitForFixedUpdate(); // ERROR ������� �S�����J
        }
    }

}
