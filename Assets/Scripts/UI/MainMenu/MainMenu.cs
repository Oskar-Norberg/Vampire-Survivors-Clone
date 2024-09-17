using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    enum MainMenuState { MainMenu, LevelSelect, OptionsMenu }
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject optionsMenu;

    private void SetState(MainMenuState state)
    {
        mainMenu.SetActive(state == MainMenuState.MainMenu);
        levelSelect.SetActive(state == MainMenuState.LevelSelect);
        optionsMenu.SetActive(state == MainMenuState.OptionsMenu);
    }

    public void GoToMainMenu()
    {
        SetState(MainMenuState.MainMenu);
    }

    public void GoToLevelSelect()
    {
        SetState(MainMenuState.LevelSelect);
    }

    public void GoToOptionsMenu()
    {
        SetState(MainMenuState.OptionsMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
