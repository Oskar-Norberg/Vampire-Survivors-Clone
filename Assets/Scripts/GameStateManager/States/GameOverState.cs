using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseGameState
{
    private GameStateManager gameStateManager;
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
        gameStateManager.Pause();
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.Resume();
    }

    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
    }
}
