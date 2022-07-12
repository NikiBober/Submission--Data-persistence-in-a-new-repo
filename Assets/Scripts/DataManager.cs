using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    readonly string saveFilePath = "/Users/Kolia/Documents/GitHub/savefile.json";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadBestScore();
    }

    public void SetName(string enterName)
    {
        playerName = enterName;
    }


    [System.Serializable]
    public class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveBestScore(int score)
    {
        SaveData data = new SaveData();
        data.bestPlayerName = playerName;
        data.bestScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(saveFilePath, json);
    }

    public void LoadBestScore()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }

}
