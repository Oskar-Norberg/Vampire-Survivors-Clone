using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using File = System.IO.File;

public static class JSONLevel
{
    [Serializable]
    private struct LevelStats
    {
        public LevelStats(string name, float time)
        {
            this.name = name;
            this.time = time;
        }
        
        public string name;
        public float time;
    }
    
    public static void SaveLevelStatsToFile(string levelName, float timeSurvived)
    {
        LevelStats level = new LevelStats(levelName, timeSurvived);
        string json = JsonUtility.ToJson(level);
        File.WriteAllText(GetPathString(levelName), json);
    }
}
