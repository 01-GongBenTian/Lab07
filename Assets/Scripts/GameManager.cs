﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private bool gameOver = false;
    private int Score = 0;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Time.timeScale == 0 && !gameOver && Input.GetKeyDown(KeyCode.Return))
            StartGame();

        /*if (Time.timeScale == 0 && gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameLose");
        }*/
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        Txt_Message.text = "GAMEOVER! \nPRESS \"ENTER\" TO CONTINUE.";
        Txt_Message.color = Color.red;
    }
}
