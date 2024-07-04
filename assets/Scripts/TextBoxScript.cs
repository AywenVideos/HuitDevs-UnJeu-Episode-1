using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
Je deteste écrire des textbox.
    - sbn
*/
public class TextBoxScript : MonoBehaviour {
    public Transform temporaryTarget;

    public GameObject textBox;
    public Text textBoxText, hudText;
    public string[] text;

    public AudioSource origin;
    public AudioClip[] voicelines;

    private static bool active;
    private int index, currentChar;

    private bool finished, isSelfActive;

    public static bool isActive() {
        return active;
    }

    public bool isFinished {
        get => finished;
    }

    private void Update() {
        if(!isSelfActive) return;

        if (text[index].Length <= currentChar && (origin == null || !origin.isPlaying))
        {
            textBoxText.text = text[index].Substring(0, Math.Min(currentChar, text[index].Length));
            hudText.text = "Appuie sur X";
            if(Input.GetKeyDown(KeyCode.X)) {
                hudText.text = "";
                currentChar = 0;
                if(index == text.Length - 1) {
                    textBoxText.text = "";
                    textBox.SetActive(false);
                    active = false;
                    isSelfActive = false;
                    finished = true;        // un hack très cheap mais flemme de faire mieux
                    CameraMoving.get.target = FindObjectOfType<PlayerController>().transform;
                } else {
                    index++;
                    if(voicelines.Length >= index) {
                        if(voicelines[index] != null) {
                            origin.clip = voicelines[index];
                            origin.Play();
                        }
                    }
                }
            }
        } else {
            textBoxText.text = text[index].Substring(0, Math.Min(currentChar, text[index].Length));
            currentChar++;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(active) return;

        if(other.tag == "Player") {
            if(Input.GetKeyDown(KeyCode.E)) {
                hudText.text = "";

                if(temporaryTarget != null)
                    CameraMoving.get.target = temporaryTarget;
                

                textBox.SetActive(true);
                index = 0;
                currentChar = 0;
                isSelfActive = true;
                active = true;

                if(voicelines[0] != null) {
                    origin.clip = voicelines[0];
                    origin.Play();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
            hudText.text = "Appuie sur E pour intéragir";
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") 
            hudText.text = "";
    }
}
