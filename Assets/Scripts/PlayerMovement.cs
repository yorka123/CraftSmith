using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float PlayerSpeed = 10f;

    Vector2 movement;

    void Update() // ���o����y��
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() // FixedUpdate()�G�ۭq���ƩI�s
    {
        rb.MovePosition(rb.position + movement * PlayerSpeed * Time.fixedDeltaTime);
    }
}
