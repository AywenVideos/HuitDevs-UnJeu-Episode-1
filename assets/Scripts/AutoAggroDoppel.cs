using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAggroDoppel : MonoBehaviour
{

    public DoppleGangerBehaviour ganger;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && ganger != null)
            ganger.triggerDoppelGanger();
    }
}
