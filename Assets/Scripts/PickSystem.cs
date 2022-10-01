using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem : MonoBehaviour
{
    bool Pick = false;
    GameObject PickObject; // �Q�ߨ�����

    private void Update()
    {
        if (Input.GetButtonDown("Submit")) // F or Enter
        {
            Pick = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            if (Input.GetButtonDown("Submit")) // F or Enter
            {
                PickObject = collision.gameObject;
                Pick = true; // ��G���F���P�w���|�Q���m(���n���S��)
                // ERROR �{�b�ܦ��b�d�򤤰����P�w�@�����\
            }

        }
    }

    private void FixedUpdate()
    {
        if (Pick)
        {
            Debug.Log("You have collected an item!");
            
            Destroy(PickObject);
            
            Pick = false;
            // �M���J���~�椧����
        }
    }
}
