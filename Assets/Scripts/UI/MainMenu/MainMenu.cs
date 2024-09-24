using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    enum MainMenuState { MainMenu, LevelSelect, OptionsMenu }

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject backButton;

    private void SetState(MainMenuState state)
    {
        mainMenu.SetActive(state == MainMenuState.MainMenu);
        levelSelect.SetActive(state == MainMenuState.LevelSelect);
        optionsMenu.SetActive(state == MainMenuState.OptionsMenu);
        
        backButton.SetActive(state != MainMenuState.MainMenu);
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
