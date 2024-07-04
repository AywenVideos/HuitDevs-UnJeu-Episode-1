using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{

    public Text text;

    public Transform newPos;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
            other.transform.position = newPos.position;
            CameraMoving.alsoFollowY = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            text.text = "Appuyez sur E pour intéragir";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            text.text = "";
        }
    }
}
