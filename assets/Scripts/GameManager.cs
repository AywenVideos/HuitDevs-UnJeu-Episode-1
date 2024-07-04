using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int coinCount = 0;
    public TMP_Text coinText;
    public AudioSource coinSound;

    public GameObject player;
    public Canvas deathPanel;
    public TextMeshProUGUI reasonOfDeath;
    public AudioSource playerOofSound;

    private void Awake()
    {
        if(instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            instance = this;
        } else if(instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }
    private void Start()
    {
        UpdateGUI();
    }
    public void IncrementCoinCount()
    {
        coinCount += 1;
        coinSound.Play();
        UpdateGUI();
    }
    public void UpdateGUI()
    {
        //coinText.text = coinCount.ToString();
    }

    public void KillPlayer(String reason)
    {
        player.SetActive(false);
        playerOofSound.loop = false;
        playerOofSound.Play();
        deathPanel.gameObject.SetActive(true);
        reasonOfDeath.text = reason;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Level()
    {
        SceneManager.LoadScene("Level");
    }
}
