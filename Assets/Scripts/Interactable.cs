using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // 待增：判定範圍(取代collider-trigger?) (NO

    public float radius;
    public Transform player;

    public virtual void Interact()
    {
        // 此函式旨於被覆寫
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < radius)
        {
                Interact();
        }
    }

    private void OnDrawGizmosSelected() // Gizmos：輔助線

    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
