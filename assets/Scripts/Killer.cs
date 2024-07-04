using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killer : MonoBehaviour
{

    private GameManager manager;

    private void Start()
    {
        manager = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.KillPlayer("Aïe..");
        }
    }
}
