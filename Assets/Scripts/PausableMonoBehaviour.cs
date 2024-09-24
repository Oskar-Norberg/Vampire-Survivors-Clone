using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PausableMonoBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        BaseGameState.onPause += Pause;
        BaseGameState.onResume += UnPause;
    }
    
    private void OnDisable()
    {
        BaseGameState.onPause -= Pause;
        BaseGameState.onResume -= UnPause;
    }

    protected abstract void Pause();
    protected abstract void UnPause();
}
