using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AywenitoWorldBehaviour : MonoBehaviour
{

    public BoxCollider2D boxCollider = null;
    public AudioSource audioSrc = null;

    private void Start()
    {
        audioSrc.Stop();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.orthographicSize = 15.0f;
            audioSrc.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Camera.main)
        {
            Camera.main.orthographicSize = 10.0f;
            audioSrc.Stop();
        }
    }
}
