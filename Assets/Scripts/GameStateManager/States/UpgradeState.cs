using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeState : BaseGameState
{
    private GameStateManager gameStateManager;
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
        gameStateManager.Pause();
        gameStateManager.upgradeMenu.SetActive(true);

        UpgradeMenu.upgradeSelectedDelegate += UpgradeApplied;
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.upgradeMenu.SetActive(false);
        gameStateManager.Resume();
        UpgradeMenu.upgradeSelectedDelegate -= UpgradeApplied;
    }
    
    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
        
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
    }

    private void UpgradeApplied(Upgrade upgrade)
    {
        gameStateManager.SwitchState<PlayingGameState>();
    }
}
