using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private WeaponManager weaponManager;

    private const string UpgradePath = "ScriptableObjects/Upgrades";
    
    public class UpgradeStatus
    {
        public Upgrade upgrade;
        public int amount;
    }
    private List<UpgradeStatus> upgrades = new List<UpgradeStatus>();
    private List<UpgradeStatus> prerequisiteUpgrades = new List<UpgradeStatus>();
    private List<UpgradeStatus> finishedUpgrades = new List<UpgradeStatus>();

    private void Start()
    {
        Upgrade[] allUpgrades = Resources.LoadAll<Upgrade>(UpgradePath);
        foreach (Upgrade upgrade in allUpgrades)
        {
            UpgradeStatus upgradeStatus = new UpgradeStatus { upgrade = upgrade, amount = 0 };
            if (upgrade is PrerequisiteUpgrade)
            {
                print("prerequisite upgrade" + upgrade.name);
                prerequisiteUpgrades.Add(upgradeStatus);
            }
            else
            {
                upgrades.Add(upgradeStatus);
            }
        }
    }
    
    public void ApplyUpgrade(Upgrade upgrade)
    {
        UpgradeStatus upgradeStatus = FindUpgradeStatus(upgrade);

        upgrade.Apply(player.gameObject);
        upgradeStatus.amount++;

        if (upgradeStatus.upgrade is GiveWeaponUpgrade)
        {
            FinishUpgrade(upgradeStatus);
        }

        if (upgrade is WeaponUpgrade)
        {
            WeaponUpgrade weaponUpgrade = (WeaponUpgrade) upgrade;
            if (upgradeStatus.amount >= weaponUpgrade.maxUpgradeCount)
            {
                FinishUpgrade(upgradeStatus);
            }
        }

        CheckPrerequisites();
    }

    private void CheckPrerequisites()
    {
        List<UpgradeStatus> toMove = new List<UpgradeStatus>();

        foreach (UpgradeStatus prerequisiteUpgradeStatus in prerequisiteUpgrades)
        {
            PrerequisiteUpgrade currentUpgrade = (PrerequisiteUpgrade) prerequisiteUpgradeStatus.upgrade;
            Upgrade prerequisite = currentUpgrade.prerequisiteUpgrade;

            bool hasPrerequisite = false;

            foreach (UpgradeStatus upgradeStatus in upgrades)
            {
                if (upgradeStatus.upgrade == prerequisite && upgradeStatus.amount > 0)
                {
                    hasPrerequisite = true;
                }
            }

            foreach (UpgradeStatus upgradeStatus in finishedUpgrades)
            {
                if (upgradeStatus.upgrade == prerequisite && upgradeStatus.amount > 0)
                {
                    hasPrerequisite = true;
                }
            }

            // If the prerequisite is found, mark for removal and addition
            if (hasPrerequisite)
            {
                print("move");
                toMove.Add(prerequisiteUpgradeStatus);
            }
        }

        foreach (UpgradeStatus upgradeStatus in toMove)
        {
            prerequisiteUpgrades.Remove(upgradeStatus);
            upgrades.Add(upgradeStatus);
        }
    }

    private void FinishUpgrade(UpgradeStatus upgradeStatus)
    {
        upgrades.Remove(upgradeStatus);
        finishedUpgrades.Add(upgradeStatus);
    }

    public Upgrade[] GetMultipleUpgrades(int upgradeCount)
    {       
        Upgrade[] returnUpgrades = new Upgrade[upgradeCount];

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
        
        // Set returnUpgrades
        for (int i = 0; i < upgradeCount; i++)
        {
            // Pick random if outside range
            if (i >= upgradeIndexes.Length)
            {
                returnUpgrades[i] = upgrades[Random.Range(0, upgrades.Count)].upgrade;
            }
            else
            {
                returnUpgrades[i] = upgrades[upgradeIndexes[i]].upgrade;
            }
        }

        return returnUpgrades;
    }

    private bool HasWeapon(GameObject weapon)
    {
        return weaponManager.FindWeapon(weapon);
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

    public List<UpgradeStatus> GetAllAppliedUpgrades()
    {
        List<UpgradeStatus> returnUpgrades = new List<UpgradeStatus>();

        foreach (UpgradeStatus upgrade in upgrades)
        {
            if (upgrade.amount > 0) returnUpgrades.Add(upgrade);
        }
        foreach (UpgradeStatus upgrade in finishedUpgrades)
        {
            if (upgrade.amount > 0) returnUpgrades.Add(upgrade);
        }

        return returnUpgrades;
    }
}
