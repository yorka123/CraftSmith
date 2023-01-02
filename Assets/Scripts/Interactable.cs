using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius;
    public Transform player;

    public virtual void Interact()
    {
        // hasInterected= true;
        // 此函式旨於被覆寫
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= radius) // 進入範圍內後，觸發Interact()
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
