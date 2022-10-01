using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSystem�j���d�� : MonoBehaviour
{
    [SerializeField] // [SerializeField]�G�Nprivate/protected�ܶq�i�ǦC�ơA�U��Ū�����ȧY���W���ᤩ����
    private Collider2D _collider2d;

    [SerializeField]
    private ContactFilter2D _contactFilter2d; //  ContactFilter2D�G�i�H�ۭq�q���I���P�w(����O�bUnity)

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            List<Collider2D> results = new List<Collider2D>(); // �ť��@��List�A���A��Collider2D�Fnew list�G�ظm�s�}�C(ex."results"���Q�гy�X���s�}�C)
            
            if (Physics2D.OverlapCollider(_collider2d, _contactFilter2d, results) > 0) // OverlapCollider(�Q�ߨ���, ����, ���|�ƶq(�^�Ǫ��ȱqresults��))
            {
                foreach (var collider2D in results) // var�G�b�sĶ�����Q�������T�����O(ex�G�{�b�OCollider2D)�Fforeach(~in results)�G�@���@��Ū��
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
