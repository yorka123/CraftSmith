using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHint : Interactable
{
    public override void Interact() // �~�� Iteract()(Interactable)
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
        pickHint.SetActive(false); // �{�b���Ѫk�O�P�w���馳�S���b���W�A�A�]�w���áA���I���W���Q�k
    }
}
