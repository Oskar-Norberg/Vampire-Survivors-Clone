using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGameState : BaseGameState
{
    public delegate void OnPauseDelegate();
    public static event OnPauseDelegate onPause;
    
    public delegate void OnResumeDelegate();
    public static event OnResumeDelegate onResume;
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager.pauseMenu.SetActive(true);
        onPause?.Invoke();
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.pauseMenu.SetActive(false);
        onResume?.Invoke();
    }
    
    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
        
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.SwitchState<PlayingGameState>();
        }
    }
}
