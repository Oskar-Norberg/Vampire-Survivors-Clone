using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState : MonoBehaviour
{
    public delegate void OnPauseDelegate();
    public static event OnPauseDelegate onPause;
    
    public delegate void OnResumeDelegate();
    public static event OnResumeDelegate onResume;
    
    public abstract void EnterState(GameStateManager gameStateManager);
    
    public abstract void ExitState(GameStateManager gameStateManager);
    
    public abstract void FixedUpdateState(GameStateManager gameStateManager);

    public abstract void UpdateState(GameStateManager gameStateManager);

    protected void Pause()
    {
        onPause?.Invoke();
    }

    protected void Resume()
    {
        onResume?.Invoke();
    }
}
