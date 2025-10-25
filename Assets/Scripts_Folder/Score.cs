using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public static Score Instance;

    private int scoreNumber1, oldScore1, scoreValue1;

    public TMP_Text ScoreText;

    public void updateValues()
    {
        //oldScore = ScoreManager.score;
        //scoreValue = ScoreManager.value;
        //ScoreManager.Invoke(oldScore, scoreValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreNumber1 = ScoreSaver.scoreNumber;
        oldScore1 = ScoreSaver.oldScore;
        scoreValue1 = ScoreSaver.scoreValue;

        updateValues();

        Bullet.scoreAdd += ScoreUpdate;
        ScoreUpdate(scoreNumber1);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreNumber1 != oldScore1)
        {
            ScoreUpdate(scoreNumber1);
            updateValues();
        }
    }

    void ScoreUpdate(int value)
    {
        scoreNumber1 += value;
        scoreValue1 = scoreNumber1;
        ScoreText.text = "Score: " + scoreValue1.ToString();

        oldScore1 = scoreNumber1;

        ScoreSaver.scoreNumber = scoreNumber1;
        ScoreSaver.oldScore = oldScore1;
        ScoreSaver.scoreValue = scoreValue1;
    }
}
