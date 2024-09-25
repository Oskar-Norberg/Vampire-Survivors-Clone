using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : PausableMonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private RegenData regenData;

    private float timer = 0.0f;
    
    private void OnEnable()
    {
        health.onHealthChange += RestartRegenerate;
        timer = 0.0f;
    }

    private void OnDisable()
    {
        health.onHealthChange -= RestartRegenerate;
    }

    private void RestartRegenerate()
    {
        timer = 0.0f;
    }

    public void FixedUpdateRegenerate()
    {
        if (IsPaused) return;
        
        timer += Time.deltaTime;
        
        if (timer >= regenData.millisecondsPerRegen / 1000)
        {
            health.Heal(regenData.healthPerTick);
            timer = 0.0f;
        }
    }
}
