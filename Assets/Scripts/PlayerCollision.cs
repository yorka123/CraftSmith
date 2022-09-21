using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) // OnTriggerStay2D: 接觸期間會持續呼叫(可能會吃效能？)
    {
        if (other.CompareTag("Collectable"))
        {

            if (Input.GetButtonDown("Fire1")) //ERROR 按鍵觸發機制奇怪
            {
                GameObject.Find("stick").GetComponent<PickedUp>().PickItem(); // 從 "stick" 物件找程式碼 "PickedUp" 並呼叫函式 "PickItem"
            }
        }
    }
}
