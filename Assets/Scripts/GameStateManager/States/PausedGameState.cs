using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGameState : BaseGameState
{
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager.pauseMenu.SetActive(true);
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.pauseMenu.SetActive(false);
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
