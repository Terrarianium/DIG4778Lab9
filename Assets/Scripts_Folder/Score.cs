using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    void ScoreUpdate()
    {
        scoreValue = scoreNumber;
        ScoreText.text = "Score: " + scoreValue.ToString();

        oldScore = scoreNumber;
    }

}
