using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallBehaviour : MonoBehaviour
{

    public float speed;
    public AudioSource audioSide;
    public AudioSource audioPaddle;
    private Vector3 direction = Vector3.one;

    private void FixedUpdate()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x >= -0.5 && viewportPosition.x <= 1.5 && viewportPosition.y >= -0.5 && viewportPosition.y <= 1.5)
        {
            transform.position += direction * speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            direction = new Vector3(direction.x, -direction.y, direction.z);
            audioSide.Play();
        } else if (collision.CompareTag("Paddle"))
        {
            direction = new Vector3(-direction.x, direction.y, direction.z);
            collision.gameObject.GetComponent<PaddleBehaviour>().Bounce();
            audioPaddle.Play();
        } else if (collision.CompareTag("Player"))
        {
            GameManager.instance.IncrementCoinCount();
            Destroy(gameObject);
        }
    }

}
