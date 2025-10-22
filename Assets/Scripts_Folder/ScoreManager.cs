[System.Serializable]

public class ScoreManager
{
    public int number;
    public int score;
    public int value;

    public ScoreManager(Score scores)
    {
        score = scores.oldScore;
        value = scores.scoreValue;
    }
}
