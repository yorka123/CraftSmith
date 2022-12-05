using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHint : Interactable
{
    public override void Interact() // 繼承 Iteract()(Interactable)
    {
        base.Interact();
        // if (hasInterected!)
        //    hide();
        // else
            appear();

    }

    public GameObject pickHint;

    void appear()
    {
        pickHint.SetActive(true);
    }

    void hide()
    {
        pickHint.SetActive(false); // 現在的解法是判定物體有沒有在表面上，再設定隱藏，有點粗糙的想法
    }
}
