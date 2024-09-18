using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager instance { get; private set; }

    private int level = 0;
    private int experience = 0;
    [SerializeField] private int experiencePerLevel = 20;
    [SerializeField] private int experiencePerLevelIncrement = 20;
    
    public delegate void OnLevelUp();
    public static event OnLevelUp onLevelUp;
    
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

    public void AddExperience(int experienceToAdd)
    {
        experience += experienceToAdd;
        if (experience >= experiencePerLevel)
        {
            LevelUp();
        }
        Debug.Log("Player is level " + level + " and has " + experience + " / " + experiencePerLevel + " experience.");
    }

    private void LevelUp()
    {
        onLevelUp?.Invoke();
        level++;
        experience = 0;
        experiencePerLevel += experiencePerLevelIncrement;
    }
}
