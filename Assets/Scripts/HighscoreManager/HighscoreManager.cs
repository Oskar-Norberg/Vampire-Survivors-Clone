using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class HighscoreManager
{
    private const string HighscoreFileName = "highscores.json";
    
    private const bool UsePrettyPrint = true;
    
    private static Dictionary<string, float> _highscores = new Dictionary<string, float>();

    [Serializable]
    private class JSONHolder
    {
        public List<JSONLevel> levels = new List<JSONLevel>();
    }

    [Serializable]
    private class JSONLevel
    {
        public string name;
        public float score;
    }

    static HighscoreManager()
    {
        LoadHighscores();
    }
    
    public static void AddScore(string levelName, float newScore)
    {
        _highscores[levelName] = newScore;

        SaveHighscores();
    }

    private static void LoadHighscores()
    {
        if (!File.Exists(GetPathString())) return;
        
        string json = File.ReadAllText(GetPathString());
        JSONHolder JSONHolder = JsonUtility.FromJson<JSONHolder>(json);

        foreach (JSONLevel JSONLevel in JSONHolder.levels)
        {
            _highscores[JSONLevel.name] = JSONLevel.score;
        }
    }
    
    private static void SaveHighscores()
    {
        JSONHolder jsonHolder = new JSONHolder();

        foreach (string key in _highscores.Keys)
        {
            jsonHolder.levels.Add(new JSONLevel { name = key, score = _highscores[key] });
        }
        
        string json = JsonUtility.ToJson(jsonHolder, UsePrettyPrint);
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
