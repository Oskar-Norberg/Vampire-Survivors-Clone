using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour
{
    [SerializeField] private Health health;
    
    [SerializeField] private RegenData regenData;
    
    private bool coroutineRunning = false;
    
    private void OnEnable()
    {
        health.onHealthChange += RestartRegenerate;
        StartCoroutine(RegenerateCoroutine());
    }

    private void OnDisable()
    {
        health.onHealthChange -= RestartRegenerate;
    }

    private void RestartRegenerate()
    {
        StopCoroutine(RegenerateCoroutine());
        StartCoroutine(RegenerateCoroutine());
    }

    private IEnumerator RegenerateCoroutine()
    {
        if (coroutineRunning) yield break;
        coroutineRunning = true;
        yield return new WaitForSeconds(regenData.millisecondsPerRegen / 1000);
        health.Heal(regenData.healthPerTick);
        coroutineRunning = false;
    }
}
