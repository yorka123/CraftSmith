using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) // OnTriggerStay2D: ��Ĳ�����|����I�s(�i��|�Y�į�H)
    {
        if (other.CompareTag("Collectable"))
        {

            if (Input.GetButtonDown("Fire1")) //ERROR ����Ĳ�o����_��
            {
                GameObject.Find("stick").GetComponent<PickedUp>().PickItem(); // �q "stick" �����{���X "PickedUp" �éI�s�禡 "PickItem"
            }
        }
    }
}
