using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCompleteTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO faire fin du jeu
        if(other.CompareTag("Player"))
        {
            //Fin du jeu
        }
    }
}
