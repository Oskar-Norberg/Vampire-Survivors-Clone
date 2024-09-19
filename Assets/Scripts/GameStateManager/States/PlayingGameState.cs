using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingGameState : BaseGameState
{

    
    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
        gameStateManager.enemyManager.FixedUpdateEnemies();
        gameStateManager.player.FixedUpdateMovement();
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.SwitchState<PausedGameState>();
        }
    }
}
