using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static ScoreScript Instance { set; get; }

    public static int score;
    private int highscore;
    public Text scoreText;
    public Text highscoreText;


    private void Awake()
    {
        Instance = this;  
    }

    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
        highscore = PlayerPrefs.GetInt("Score");
        highscoreText.text = "BEST:" + highscore.ToString();
    }

    void Update()
    {
        
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void IncrementScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "BEST:" + highscore.ToString();
            PlayerPrefs.SetInt("Score", highscore);
        }
    }
}
