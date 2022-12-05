using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius;
    public Transform player;

    public bool hasInterected = false;

    public virtual void Interact()
    {
        hasInterected= true;
        // 此函式旨於被覆寫
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= radius)
        {
            hasInterected = true;
            
            if (radius == distance) // Call不到，有可能因為判定太準確了(精準要那個距離)，可能需要另外一個distance界定邊緣範圍
                {
                    Debug.Log("Touch Edge");
                    hasInterected= false;
                }
            Interact();
        }
    }

    private void OnDrawGizmosSelected() // Gizmos：輔助線

    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
