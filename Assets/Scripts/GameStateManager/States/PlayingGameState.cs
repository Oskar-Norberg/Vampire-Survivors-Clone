using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingGameState : BaseGameState
{
    // Foul hack, but the only way to pass gameStateManager to OnLevelUp function.
    private GameStateManager gameStateManager;
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
        ExperienceManager.onLevelUp += OnLevelUp;
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        ExperienceManager.onLevelUp -= OnLevelUp;
    }

    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
        
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.SwitchState<PausedGameState>();
        }
    }

    private void OnLevelUp()
    {
        if (!gameStateManager)
        {
            Debug.Log("Game State Manager missing in PlayingGameState, skipping level up");
        }
        gameStateManager.SwitchState<UpgradeState>();
    }
}
