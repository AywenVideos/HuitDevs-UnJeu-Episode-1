using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoppleGangerBehaviour : MonoBehaviour {
    public TextBoxScript script;

    public Sprite[] textures;

    private SpriteRenderer sRenderer;

    private bool onFinish;

    private bool force;

    private GameObject playerTarget;

    public Rigidbody2D body;

    void Start() {
        sRenderer = GetComponent<SpriteRenderer>();
        playerTarget = FindObjectOfType<PlayerController>().gameObject;
    }
    int frameSinceStart = 0;

    void Update() {
        if((force || script.isFinished) && sRenderer != null) {
            if(!onFinish) {
                sRenderer.sprite = textures[1];
                frameSinceStart = 300;
                GetComponent<Collider2D>().enabled = false; // <--- empêche de pouvoir trigger le dialogue une fois activé
                onFinish = true;
            }
        } else {
            return;
        }
        
        int mul = 0; // reste immobile

        if(playerTarget.transform.position.x < transform.position.x) mul = -1;
        else mul = 1;
        int speed = 300;

        if(frameSinceStart >= 1)
            speed = (int) 300 / frameSinceStart;

        body.velocity = new Vector2(speed * mul * Time.deltaTime, 0);

        frameSinceStart-=5;

        if(Vector2.Distance(playerTarget.transform.position, transform.position) <= 2) {
            SceneManager.LoadScene("XederScare");
        }
    }

    public void triggerDoppelGanger() {
        force = true;
    }
}
