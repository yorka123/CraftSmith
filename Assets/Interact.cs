using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // �ݼW�G�P�w�d��(���Ncollider-trigger?)

    public float radius = 3f;
    public Transform interactionTransform;

    bool hasIteracted = false;

    public virtual void Interact()
    {
        // ���禡����Q�мg
        Debug.Log("Interacting");

    }

}
