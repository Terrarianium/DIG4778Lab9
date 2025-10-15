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
        Bullet.AddScore += ScoreUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreNumber != oldScore)
        {
            ScoreUpdate();
        }
    }

    void ScoreUpdate(int score)
    {
        ScoreText.text = "Score: " + scoreNumber.ToString();

        scoreNumber = oldScore;
    }

}
