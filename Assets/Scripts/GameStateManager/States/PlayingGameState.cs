using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingGameState : BaseGameState
{

    
    public override void EnterState(GameStateManager gameStateManager)
    {
        
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        
    }

    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
        gameStateManager.waveSpawner.FixedUpdateWaveTimer();
        gameStateManager.enemyManager.FixedUpdateEnemies();
        gameStateManager.player.FixedUpdatePlayer();
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.SwitchState<PausedGameState>();
        }
    }
}
