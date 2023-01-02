using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float PlayerSpeed = 10f;

    Vector2 movement;

    void Update() // 取得角色座標
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() // FixedUpdate()：自訂次數呼叫
    {
        rb.MovePosition(rb.position + movement * PlayerSpeed * Time.fixedDeltaTime);
    }
}
