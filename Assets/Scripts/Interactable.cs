using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // �ݼW�G�P�w�d��(���Ncollider-trigger?) (NO

    public float radius;
    public Transform player;

    public virtual void Interact()
    {
        // ���禡����Q�мg
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < radius)
        {
                Interact();
        }
    }

    private void OnDrawGizmosSelected() // Gizmos�G���U�u

    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
