using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static int scoreNumber;
    private int oldScore;
    private int scoreValue;

    public TMP_Text ScoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        oldScore = 0;
        scoreValue = 0;
        Bullet.scoreAdd += ScoreUpdate;
        ScoreUpdate(scoreNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreNumber != oldScore)
        {
            ScoreUpdate(scoreNumber);
        }
    }

    void ScoreUpdate(int value)
    {
        scoreNumber += value;
        scoreValue = scoreNumber;
        ScoreText.text = "Score: " + scoreValue.ToString();

        oldScore = scoreNumber;
    }
}
