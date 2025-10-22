using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class ScoreSaver
{
    public static string directory = "SaveData";
    public static string fileName = "MySave.comp3";

    public static void Save(ScoreManager score)
    {
        if (!DirectoryExists())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath());
        bf.Serialize(file, score);
        file.Close();
        Debug.Log("File closed");
    }

    public static ScoreManager Load()
    {
        if (SaveExists())
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(), FileMode.Open);
                ScoreManager score = (ScoreManager)bf.Deserialize(file);
                file.Close();

                return score;
            }
            catch (SerializationException)
            {
                Debug.Log("Failed to load file");
            }
        }

        return null;
    }

    private static bool SaveExists()
    {
        return File.Exists(GetFullPath());
    }

    private static bool DirectoryExists()
    { 
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }

    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + directory + "/" + fileName;
    }


}
