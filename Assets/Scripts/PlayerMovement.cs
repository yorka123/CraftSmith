using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float PlayerSpeed = 10f;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() // �����z���F���(�I�s15��persec)
    {
        rb.MovePosition(rb.position + movement * PlayerSpeed * Time.fixedDeltaTime);
    }
}