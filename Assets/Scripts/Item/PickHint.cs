using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHint : Interactable
{
    public override void Interact() // �~�� Iteract()(Interactable)
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
        pickHint.SetActive(false); // �����D�n���Ĳ�o
    }
}
