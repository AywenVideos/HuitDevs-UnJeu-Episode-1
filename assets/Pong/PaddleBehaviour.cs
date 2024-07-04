using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{

    public Transform target;
    public Transform player;
    public float speed;
    public float minY;
    public float maxY;
    public bool enable;
    public PaddleBehaviour otherPaddle;

    private void FixedUpdate()
    {
        if (target == null)
        {
            target = player;
            enable = true;
            speed *= 0.8f;
        }
        if (enable)
        {
            transform.position += Vector3.up * Time.fixedDeltaTime * speed * Mathf.Sign(target.position.y - transform.position.y);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        }
    }

    public void Bounce()
    {
        enable = false;
        otherPaddle.enable = true;
    }

}
