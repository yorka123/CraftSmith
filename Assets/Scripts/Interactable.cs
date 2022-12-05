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
        // ���禡����Q�мg
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= radius)
        {
            hasInterected = true;
            
            if (radius == distance) // Call����A���i��]���P�w�ӷǽT�F(��ǭn���ӶZ��)�A�i��ݭn�t�~�@��distance�ɩw��t�d��
                {
                    Debug.Log("Touch Edge");
                    hasInterected= false;
                }
            Interact();
        }
    }

    private void OnDrawGizmosSelected() // Gizmos�G���U�u

    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
