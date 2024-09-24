using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseGameState
{
    public override void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager.gameOverMenu.SetActive(true);
        gameStateManager.Pause();
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.gameOverMenu.SetActive(false);
        gameStateManager.Resume();
    }

    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
    }
}
