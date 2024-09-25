using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PausableMonoBehaviour : MonoBehaviour
{
    protected bool IsPaused = false;
    
    private void OnEnable()
    {
        GameStateManager.onPause += Pause;
        GameStateManager.onResume += UnPause;
    }
    
    private void OnDisable()
    {
        GameStateManager.onPause -= Pause;
        GameStateManager.onResume -= UnPause;
    }

    protected virtual void Pause(){ IsPaused = true; }
    protected virtual void UnPause(){ IsPaused = false; }
}
