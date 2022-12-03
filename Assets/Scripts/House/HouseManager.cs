using UnityEngine;

public class HouseManager : MonoBehaviour
{

    public SpriteRenderer HausORend;
    private Color HausOColor;

    void Start()
    {
        HausOColor = HausORend.GetComponent<SpriteRenderer>().color;
        HausOColor = HausORend.color;
        HausOColor.a = 255f; // 使實心 OK但怪怪的
       HausORend.color = HausOColor;
    }
}
