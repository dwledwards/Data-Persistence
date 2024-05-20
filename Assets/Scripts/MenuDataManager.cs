using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuDataManager : MonoBehaviour
{
    private string highScoreName;
    private string currentPlayerName;
    private int score;

    public static MenuDataManager Instance;

    private const string saveFile = "/savefile.json";

    public string HighScoreName
    {
        get { return highScoreName; }
        set { highScoreName = value; }
    }


    public string CurrentPlayerName
    {
        get { return currentPlayerName; }
        set { currentPlayerName = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        LoadData();
    }

    [Serializable]
    class GameData
    {
        public string Name;
        public int Score;
    }

    public void SaveData()
    {
        GameData data = new GameData();
        data.Name = HighScoreName;
        data.Score = Score;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + saveFile, jsonData);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + saveFile;
        if(File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(jsonData);

            HighScoreName = data.Name;
            Score = data.Score;
        }
    }
}
