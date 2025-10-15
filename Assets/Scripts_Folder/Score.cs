using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    private int scoreNumber;
    private int oldScore;

    public TMP_Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        oldScore = 0;
        ScoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreNumber != oldScore)
        {
            ScoreUpdate();
        }
    }

    void Enemy1Score()
    {
        scoreNumber += 5;
    }

    void Enemy2Score()
    {
        scoreNumber += 10;
    }

    void ScoreUpdate()
    {
        ScoreText.text = "Score: " + scoreNumber.ToString();

        scoreNumber = oldScore;
    }

}
