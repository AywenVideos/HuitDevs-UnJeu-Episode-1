using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public TextMeshProUGUI TimerText = null;
    public Rigidbody2D Player = null;
    public int Timer = 30;

    private bool playerKilled;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(TimerUpdate), 2.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TimerUpdate()
    {
        if(!TimerText) return;
        if (Player.velocity != Vector2.zero)
        {
            Timer = 30;
            TimerText.text = Timer.ToString() + "s";
            return;
        }
        if (Timer == 0)
        {
            if (!playerKilled)
            {
                GameManager.instance.KillPlayer("Tu n'as pas assez bougé ! (flemmard en attendant vas faire des pâte )");
                playerKilled = true;
                return;
            }
        }
        Timer --;
        TimerText.text = Timer.ToString() + "s";
    }
}
