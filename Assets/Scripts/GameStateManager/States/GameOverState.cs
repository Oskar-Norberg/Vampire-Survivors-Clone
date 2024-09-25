using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseGameState
{
    private GameStateManager gameStateManager;
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
        gameStateManager.gameOverMenu.SetActive(true);
        gameStateManager.Pause();

        GameOverMenu.mainMenu += GoToMainMenu;
    }

    public override void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.gameOverMenu.SetActive(false);
        gameStateManager.Resume();
        GameOverMenu.mainMenu -= GoToMainMenu;
    }

    public override void FixedUpdateState(GameStateManager gameStateManager)
    {
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
    }

    private void GoToMainMenu()
    {
        gameStateManager.GoToMainMenu();
    }
}
