using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class HighscoreManager
{
    public static HighscoreManager instance;
    
    private const string HighscoreFileName = "Highscores.json";
    
    private Dictionary<string, float> highscore = new Dictionary<string, float>();

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
    {
        LoadHighscores();
    }

    public void AddScore(string levelName, float newScore)
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
    {
        SaveHighscores();
    }

    private void LoadHighscores()
    {
        if (File.Exists(GetPathString()))
        {
            string json = File.ReadAllText(GetPathString());
            highscore = JsonUtility.FromJson<Dictionary<string, float>>(json);
        }
    }
    
    private void SaveHighscores()
    {
        string json = JsonUtility.ToJson(highscore);
        File.WriteAllText(GetPathString(), json);
    }
    
    public float GetHighscore(string levelName)
    {
        return highscore[levelName];
    }
    
    public bool HasPreviousScore(string levelName)
    {
        return highscore.ContainsKey(levelName);
    }
    
    private static string GetPathString()
    {
        return Application.persistentDataPath + "/" + HighscoreFileName;
    }
}
