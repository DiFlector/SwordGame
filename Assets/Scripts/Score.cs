using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    private Text score, highScore;
    public int scoreCounter, highScoreCounter;

    private void Awake()
    {
        instance = this;

        if(PlayerPrefs.HasKey("HighScore")) highScoreCounter = PlayerPrefs.GetInt("HighScore");
    }

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();

        scoreCounter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().level;
        highScoreCounter = scoreCounter > highScoreCounter ? scoreCounter : highScoreCounter;

        PlayerPrefs.SetInt("HighScore", highScoreCounter);

        score.text = "SCORE: " + scoreCounter;
        highScore.text = "HIGH SCORE: " + highScoreCounter;
    }
}
