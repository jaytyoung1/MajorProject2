﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTextBox;

    [HideInInspector]
    public static int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        PlayerPrefs.DeleteKey("Score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextBox.text = "Score: " + PlayerPrefs.GetInt("Score");
    }

    public void incrementScore()
    {
        score = score + 1;
        PlayerPrefs.SetInt("Score", score);
        scoreTextBox.text = "Score: " + PlayerPrefs.GetInt("Score");
        //displayScore();
        Debug.Log("increment score");
    }
}
