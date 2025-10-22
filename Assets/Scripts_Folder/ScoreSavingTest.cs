using UnityEngine;

public class ScoreSavingTest : MonoBehaviour
{
    public ScoreManager score;
    void OnSave()
    {
        Debug.Log("Began Saving");
        ScoreSaver.Save(score);
    }

    void OnLoad()
    {
        Debug.Log("Began Loading");
        score = ScoreSaver.Load();
    }

}
