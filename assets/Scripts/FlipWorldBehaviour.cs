using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWorldBehaviour : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private AudioSource audioSource;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public static float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return ((value - fromMin) / (fromMax - fromMin)) * (toMax - toMin) + toMin;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.transform.rotation = Quaternion.Euler(0f, 0f,
                Map(collision.transform.position.x, boxCollider.bounds.min.x, boxCollider.bounds.max.x, 0f, -360f)
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Camera.main)
        {
            Camera.main.transform.rotation = Quaternion.identity;
            audioSource.Stop();
        }
    }
}
