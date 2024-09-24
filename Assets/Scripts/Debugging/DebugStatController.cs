using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStatController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ExperienceManager experienceManager;

    private Health health;
    
    private bool godMode = false;

    private void Start()
    {
        health = playerController.GetComponent<Health>();
    }

    private void Update()
    {
        // Enable godMode
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            godMode = !godMode;
            if (godMode)
            {
                health.IncreaseMaxHealth(99999);
            }
            else
            {
                health.IncreaseMaxHealth(-99999);
                health.SetHealth(health.GetMaxHealth());
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            experienceManager.AddExperience(99999);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Time.timeScale = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Time.timeScale = 5;
        }
    }

    private void FixedUpdate()
    {
        if (godMode)
        {
            health.SetHealth(health.GetMaxHealth());
        }
    }
}
