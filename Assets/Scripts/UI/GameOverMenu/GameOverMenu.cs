using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public delegate void MainMenuDelegate();
    public static event MainMenuDelegate mainMenu;

    public void OnClickMainMenu()
    {
        mainMenu?.Invoke();
    }
}
