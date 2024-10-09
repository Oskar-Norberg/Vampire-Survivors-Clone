using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
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
}
