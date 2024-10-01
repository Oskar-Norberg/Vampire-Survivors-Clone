using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private RoundTimer roundTimer;
    [SerializeField] private UpgradeManager upgradeManager;
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI upgradeListText;
    
    public delegate void MainMenuDelegate();
    public static event MainMenuDelegate mainMenu;

    private void OnEnable()
    {
        timerText.text = roundTimer.GetFormattedString();
        SetUpgradeList();
    }

    public void OnClickMainMenu()
    {
        mainMenu?.Invoke();
    }

    private void SetUpgradeList()
    {
        string text = "";
        foreach (UpgradeManager.UpgradeStatus upgrade in upgradeManager.GetAllAppliedUpgrades())
        {
            text += upgrade.upgrade.name + " x" + upgrade.amount + "\n\n";
        }
        upgradeListText.text = text;
    }
}
