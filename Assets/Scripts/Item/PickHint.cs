using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHint : Interactable
{
    public override void Interact() // 繼承 Iteract()(Interactable)
    {
        base.Interact();
        appear();
        
    }

    public GameObject pickHint;

    void appear()
    {
        pickHint.SetActive(true);
    }

    void Hide()
    {
        pickHint.SetActive(false); // 不知道要怎麼觸發
    }
}
