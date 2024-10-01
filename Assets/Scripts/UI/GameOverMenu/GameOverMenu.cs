using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private RoundTimer roundTimer;
    
    [SerializeField] private TextMeshProUGUI timerText;
    
    public delegate void MainMenuDelegate();
    public static event MainMenuDelegate mainMenu;

    private void OnEnable()
    {
        timerText.text = roundTimer.GetFormattedString();
    }

    public void OnClickMainMenu()
    {
        mainMenu?.Invoke();
    }
}
