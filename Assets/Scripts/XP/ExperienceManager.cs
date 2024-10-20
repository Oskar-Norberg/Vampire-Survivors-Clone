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
    
    public delegate void OnExperienceChanged();
    public static event OnExperienceChanged onExperienceChanged;
    
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
        onExperienceChanged?.Invoke();
    }

    private void LevelUp()
    {
        onLevelUp?.Invoke();
        level++;
        experience = 0;
        experiencePerLevel += experiencePerLevelIncrement;
    }

    public int GetExperience()
    {
        return experience;
    }

    public int GetLevel()
    {
        return level;
    }
    
    public int GetExperiencePerLevel()
    {
        return experiencePerLevel;
    }
}
