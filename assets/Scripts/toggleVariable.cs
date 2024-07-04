using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleVariable : MonoBehaviour {

    public bool toggleType;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
            CameraMoving.alsoFollowY = toggleType;
    }
}
