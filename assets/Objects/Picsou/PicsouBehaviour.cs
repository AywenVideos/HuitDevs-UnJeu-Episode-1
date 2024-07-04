using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicsouBehaviour : MonoBehaviour
{

    public GameObject spawnObject;
    public int spawnNumber;
    public float spawnDelay;
    public float spawnAccel;
    public float spawnY;
    public float spawnMinX;
    public float spawnMaxX;

    private AudioSource audioSource;
    private int instantiatedObjects = -1;
    private float spawnTime = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && instantiatedObjects == -1)
        {
            instantiatedObjects = 0;
        }
    }

    private void Update()
    {
        if (instantiatedObjects != -1)
        {
            if (instantiatedObjects < spawnNumber)
            {
                if (spawnTime + spawnDelay <= Time.time)
                {
                    Instantiate(spawnObject, new Vector3(Random.Range(spawnMinX, spawnMaxX), spawnY, 0), Quaternion.identity);
                    if (spawnDelay > -0.5f)
                    {
                        audioSource.Play();
                    }
                    instantiatedObjects++;
                    spawnDelay -= spawnAccel;
                    spawnTime = Time.time;
                }
            }
            else
            {
                Destroy(this);
            }
        }
    }

}
