using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGameState : BaseGameState
{
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager.pauseMenu.SetActive(true);
        gameStateManager.Pause();
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.pauseMenu.SetActive(false);
        gameStateManager.Resume();
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
