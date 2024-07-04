using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareScript : MonoBehaviour
{

    public GameObject screamer;

    public AudioSource ears;

    private Transform screamerPos;

    // Start is called before the first frame update
    void Start()
    {
        screamerPos = screamer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        screamer.transform.position = screamerPos.position + Random.insideUnitSphere * 1.25f;

        if(!ears.isPlaying) {
            SceneManager.LoadScene("Level");
        }
    }
}
