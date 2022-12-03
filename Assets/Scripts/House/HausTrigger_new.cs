using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HausTrigger_new : MonoBehaviour
{

    [SerializeField] private Animator Animator; //serialize field �M public ���t���H


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) // CompareTag: ��.tag== �@�ˡA���t�פ����
        {
            
            Animator.SetBool("TriggerIn", true);
            // Fade Out
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            
            Animator.SetBool("TriggerIn", false);
            // Fade in
        }
    }
}
