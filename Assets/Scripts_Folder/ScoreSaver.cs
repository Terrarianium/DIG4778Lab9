using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ScoreSaver
{
    public static int scoreNumber;
    public static int oldScore;
    public static int scoreValue;

    public static void Save(ScoreManager score)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/save.dat");
        }
        ScoreManager scores1 = new ScoreManager();
        scores1.score1 = scoreNumber;
        scores1.value1 = scoreValue;

        bf.Serialize(file, scores1);
        file.Close();
        Debug.Log("File closed");
    }

    public static ScoreManager Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
                ScoreManager scores1 = (ScoreManager)bf.Deserialize(file);

                scoreValue = scores1.value1;
                scoreValue = scores1.value1;


                file.Close();

                Debug.Log("Loading");
            }
            catch (SerializationException)
            {
                Debug.Log("Failed to load file");
            }
        }

        return null;
    }

}

[System.Serializable]
public class ScoreManager
{
    public int score1;
    public int value1;

    public ScoreManager()
    {
        score1 = new int();
        value1 = new int();
    }

}
