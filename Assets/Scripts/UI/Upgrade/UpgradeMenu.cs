using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    
    [SerializeField] private List<UpgradeCard> upgradeCards = new List<UpgradeCard>();
    
    public delegate void UpgradeSelectedDelegate(Upgrade upgrade);
    public static event UpgradeSelectedDelegate upgradeSelectedDelegate;

    private void OnEnable()
    {
        SetCardUpgrades();

        UpgradeCard.onClick += SelectUpgradeCard;
    }

    private void OnDisable()
    {
        UpgradeCard.onClick -= SelectUpgradeCard;
    }
    
    private void SetCardUpgrades()
    {
        Upgrade[] upgrades = upgradeManager.GetNonDuplicateUpgrades(upgradeCards.Count);
        
        for (int i = 0; i < upgradeCards.Count; i++)
        {
            upgradeCards[i].SetUpgrade(upgrades[i]);
        }
    }

    private void SelectUpgradeCard(Upgrade upgrade)
    {
        upgradeManager.ApplyUpgrade(upgrade);
        upgradeSelectedDelegate?.Invoke(upgrade);
    }
}
