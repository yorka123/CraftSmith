using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // �ݼW�G�P�w�d��(���Ncollider-trigger?) (NO

    public float radius = 0.01f;
    public Transform interactionTransform;

    bool hasIteracted = false;

    private void OnDrawGizmosSelected() // Gizmos�G���U�u (+ https://dotblogs.com.tw/coolgamedevnote/2018/03/04/211220

    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        // ���禡����Q�мg
        Debug.Log("Interacting");

    }

}
