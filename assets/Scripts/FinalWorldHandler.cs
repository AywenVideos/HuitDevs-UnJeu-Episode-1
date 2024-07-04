using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeWorldHandler : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO Bonne chance !
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
