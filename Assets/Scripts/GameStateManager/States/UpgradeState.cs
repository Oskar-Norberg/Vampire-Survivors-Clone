using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeState : BaseGameState
{
    public override void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager.upgradeMenu.SetActive(true);
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.upgradeMenu.SetActive(false);
    }
    
    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
        
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
    }
}
