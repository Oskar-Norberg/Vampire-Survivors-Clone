using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : BaseGameState
{
    private GameStateManager gameStateManager;
    
    public override void EnterState(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
        gameStateManager.gameOverMenu.SetActive(true);
        gameStateManager.Pause();

        SaveTimeSurvived(gameStateManager);

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

    private void SaveTimeSurvived(GameStateManager gameStateManager)
    {
        float timeSurvived = gameStateManager.roundTimer.GetTimeInSeconds();
        
        PlayerPrefs.SetFloat("TimeSurvived" + SceneManager.GetActiveScene().name, timeSurvived);
    }
}
