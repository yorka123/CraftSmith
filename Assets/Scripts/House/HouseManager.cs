using UnityEngine;

public class HouseManager : MonoBehaviour
{

    public SpriteRenderer HausORend;
    private Color HausOColor;

    void Start()
    {
        HausOColor = HausORend.GetComponent<SpriteRenderer>().color;
        HausOColor = HausORend.color;
        HausOColor.a = 255f; // �Ϲ�� OK���ǩǪ�
       HausORend.color = HausOColor;
    }
}
