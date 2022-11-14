using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // 待增：判定範圍(取代collider-trigger?)

    public float radius = 3f;
    public Transform interactionTransform;

    bool hasIteracted = false;

    public virtual void Interact()
    {
        // 此函式旨於被覆寫
        Debug.Log("Interacting");

    }

}
