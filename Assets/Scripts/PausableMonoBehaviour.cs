using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PausableMonoBehaviour : MonoBehaviour
{
    protected bool IsPaused = false;
    
    protected virtual void OnEnable()
    {
        GameStateManager.onPause += Pause;
        GameStateManager.onResume += UnPause;
    }
    
    protected virtual void OnDisable()
    {
        GameStateManager.onPause -= Pause;
        GameStateManager.onResume -= UnPause;
    }

    protected virtual void Pause(){ IsPaused = true; }
    protected virtual void UnPause(){ IsPaused = false; }
}
