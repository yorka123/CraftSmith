using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem2 : MonoBehaviour
{
    [SerializeField]
    private Collider2D _collider2d;

    [SerializeField]
    private ContactFilter2D _contactFilter2d; // ContactFilter2D�O����H

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            List<Collider2D> results = new List<Collider2D>(); // �ť��@��List�A���A��Collider2D
            if (Physics2D.OverlapCollider(_collider2d, _contactFilter2d, results) > 0) // OverlapCollider�S�Oԣ�H�H
            {
                foreach (var collider2D in results) // var�G�b�sĶ�����Q�������T�����O(ex�G�{�b�OCollider2D)
                {
                    if (collider2D.CompareTag("Collectable"))
                    {
                        //�߰_���~

                        Destroy(collider2D.gameObject);
                    }
                }
            }
        }
    }
}
