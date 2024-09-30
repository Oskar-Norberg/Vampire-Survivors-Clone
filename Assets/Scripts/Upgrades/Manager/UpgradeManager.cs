using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private const string UpgradePath = "ScriptableObjects/Upgrades";
    
    public class UpgradeStatus
    {
        public Upgrade upgrade;
        public int amount;
    }
    private List<UpgradeStatus> upgrades = new List<UpgradeStatus>();

    private void Start()
    {
        Upgrade[] allUpgrades = Resources.LoadAll<Upgrade>(UpgradePath);
        foreach (Upgrade upgrade in allUpgrades)
        {
            upgrades.Add(new UpgradeStatus { upgrade = upgrade, amount = 0 });
        }
    }
    
    public void ApplyUpgrade(Upgrade upgrade)
    {
        upgrade.Apply(player.gameObject);
    }

    public Upgrade[] GetNonDuplicateUpgrades(int upgradeCount)
    {
        Upgrade[] nonDuplicateUpgrades = new Upgrade[upgradeCount];
        
        // Array of all possible indexes
        int[] upgradeIndexes = new int[upgrades.Count];
        
        for (int i = 0; i < upgrades.Count; i++)
        {
            upgradeIndexes[i] = i;
        }
        
        // Randomize indexes
        for (int i = 0; i < upgrades.Count; i++)
        {
            int index1 = Random.Range(0, upgradeIndexes.Length);
            int index2 = Random.Range(0, upgradeIndexes.Length);
            
            (upgradeIndexes[index1], upgradeIndexes[index2]) = (upgradeIndexes[index2], upgradeIndexes[index1]);
        }

        // Grab three first indexes, which are randomized
        for (int i = 0; i < upgradeCount; i++)
        {
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
