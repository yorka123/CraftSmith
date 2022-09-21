using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HausTrigger_new : MonoBehaviour
{

    [SerializeField] private Animator Animator; //serialize field 和 public 的差異？


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) // CompareTag: 跟.tag== 一樣，但速度比較快
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
