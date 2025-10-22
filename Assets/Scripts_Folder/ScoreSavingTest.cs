using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSavingTest : MonoBehaviour
{
    public Score score;
    void OnSave()
    {
        ScoreSaver.Save(score);
    }

    void OnLoad()
    {
        score = ScoreSaver.Load();
    }

}
