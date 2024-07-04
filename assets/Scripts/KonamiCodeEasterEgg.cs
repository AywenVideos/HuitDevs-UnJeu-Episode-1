using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Oui, je l'ai volé sur internet, mais pour ma défense, j'avais plus bcp d'temps. (https://www.thepolyglotdeveloper.com/2021/09/implement-konami-keystroke-cheat-code-unity-game/)

public class KonamiCodeEasterEgg : MonoBehaviour
{

    private List<string> _keyStrokeHistory;

    void Awake()
    {
        _keyStrokeHistory = new List<string>();
    }

    void Update()
    {
        KeyCode keyPressed = DetectKeyPressed();
        AddKeyStrokeToHistory(keyPressed.ToString());
        if (GetKeyStrokeHistory().Equals("UpArrow,UpArrow,DownArrow,DownArrow,LeftArrow,RightArrow,LeftArrow,RightArrow,B,Q"))
        {
            SceneManager.LoadScene("XederScare");
            ClearKeyStrokeHistory();
        }
    }



    private KeyCode DetectKeyPressed()
    {
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                return key;
            }
        }
        return KeyCode.None;
    }

    private void AddKeyStrokeToHistory(string keyStroke)
    {
        if (!keyStroke.Equals("None"))
        {
            _keyStrokeHistory.Add(keyStroke);
            if (_keyStrokeHistory.Count > 10)
            {
                _keyStrokeHistory.RemoveAt(0);
            }
        }
    }

    private string GetKeyStrokeHistory()
    {
        return String.Join(",", _keyStrokeHistory.ToArray());
    }

    private void ClearKeyStrokeHistory()
    {
        _keyStrokeHistory.Clear();
    }
}
