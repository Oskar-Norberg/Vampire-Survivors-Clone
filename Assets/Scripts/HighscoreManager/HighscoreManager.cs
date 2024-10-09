using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class HighscoreManager
{
    private const string HighscoreFileName = "highscores.json";
    
    
    private static Dictionary<string, float> _highscores = new Dictionary<string, float>();

    private void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        }
        else 
        { 
            instance = this; 
        } 
    }

    private void Start()
    [Serializable]
    private class JSONLevel
    {
        public string name;
        public float score;
    }

    static HighscoreManager()
    {
        if (highscore.ContainsKey(levelName))
        {
            highscore[levelName] = newScore;
        }
        else
        {
            highscore.Add(levelName, newScore);
        }
    }

    private void OnApplicationQuit()
    
    public static void AddScore(string levelName, float newScore)
    {
        SaveHighscores();
    }

    private static void LoadHighscores()
    {
        if (File.Exists(GetPathString()))
        {
            string json = File.ReadAllText(GetPathString());
            highscore = JsonUtility.FromJson<Dictionary<string, float>>(json);
        }
    }
    
    private static void SaveHighscores()
    {
        string json = JsonUtility.ToJson(highscore);
        File.WriteAllText(GetPathString(), json);
    }
    
    public static float GetHighscore(string levelName)
    {
        return _highscores[levelName];
    }
    
    public static bool HasPreviousScore(string levelName)
    {
        return _highscores.ContainsKey(levelName);
    }
    
    private static string GetPathString()
    {
        return Application.persistentDataPath + "/" + HighscoreFileName;
    }
}
