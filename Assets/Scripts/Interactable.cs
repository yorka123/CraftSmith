using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius;
    public Transform player;

    public virtual void Interact()
    {
        // hasInterected= true;
        // ���禡����Q�мg
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= radius) // �i�J�d�򤺫�AĲ�oInteract()
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
