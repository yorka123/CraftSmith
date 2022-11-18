using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // 待增：判定範圍(取代collider-trigger?) (NO

    public float radius = 0.01f;
    public Transform interactionTransform;

    bool hasIteracted = false;

    private void OnDrawGizmosSelected() // Gizmos：輔助線 (+ https://dotblogs.com.tw/coolgamedevnote/2018/03/04/211220

    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        // 此函式旨於被覆寫
        Debug.Log("Interacting");

    }

}
