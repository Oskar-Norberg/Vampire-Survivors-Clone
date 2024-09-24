using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PausableMonoBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        PausedGameState.onPause += Pause;
        PausedGameState.onResume += UnPause;
    }
    
    private void OnDisable()
    {
        PausedGameState.onPause -= Pause;
        PausedGameState.onResume -= UnPause;
    }

    protected abstract void Pause();
    protected abstract void UnPause();
}
