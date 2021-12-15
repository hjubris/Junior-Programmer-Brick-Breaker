using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveGame
{    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public static void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = ScoreKeeper.highScore;
        data.highScoreName = ScoreKeeper.highScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public static void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            ScoreKeeper.highScore = data.highScore;
            ScoreKeeper.highScoreName = data.highScoreName;
        }
    }
}
