using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private const string UpgradePath = "ScriptableObjects/Upgrades";
    
    private Upgrade[] upgrades;

    private void Start()
    {
        upgrades = Resources.LoadAll<Upgrade>(UpgradePath);
    }
    
    public void ApplyUpgrade(Upgrade upgrade)
    {
        upgrade.Apply(player.gameObject);
    }

    public Upgrade[] GetNonDuplicateUpgrades(int upgradeCount)
    {
        Upgrade[] nonDuplicateUpgrades = new Upgrade[upgradeCount];
        
        // Array of all possible indexes
        int[] upgradeIndexes = new int[upgrades.Length];
        
        for (int i = 0; i < upgrades.Length; i++)
        {
            upgradeIndexes[i] = i;
        }
        
        // Randomize indexes
        for (int i = 0; i < upgrades.Length; i++)
        {
            int index1 = Random.Range(0, upgradeIndexes.Length);
            int index2 = Random.Range(0, upgradeIndexes.Length);
            
            (upgradeIndexes[index1], upgradeIndexes[index2]) = (upgradeIndexes[index2], upgradeIndexes[index1]);
        }

        // Grab three first indexes, which are randomized
        for (int i = 0; i < upgradeCount; i++)
        {
            nonDuplicateUpgrades[i] = upgrades[upgradeIndexes[i]];
        }

        return nonDuplicateUpgrades;
    }

    private UpgradeStatus FindUpgradeStatus(Upgrade upgrade)
    {
        foreach (UpgradeStatus upgradeStatus in upgrades)
        {
            if (upgradeStatus.upgrade == upgrade)
            {
                return upgradeStatus;
            }
        }

        return null;
    }
}
