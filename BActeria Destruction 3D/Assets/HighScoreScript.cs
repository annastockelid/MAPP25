using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public int scoreValue;

    private int highscore;
    public Text highscoreText;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Score");
        highscoreText.text = "BEST:" + highscore.ToString();
    }


    public void setHighscore()
    {
        if (scoreValue > highscore)
        {
            highscore = scoreValue;
            highscoreText.text = "BEST:" + highscore.ToString();
            PlayerPrefs.SetInt("Score", highscore);
        }
    }
}
