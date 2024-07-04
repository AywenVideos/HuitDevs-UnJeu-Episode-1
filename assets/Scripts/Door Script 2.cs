using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript2 : MonoBehaviour
{
    public Text text;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene("Menu");
            CameraMoving.alsoFollowY = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            text.text = "Appuyez sur E pour interagir";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            text.text = "";
        }
    }
}
