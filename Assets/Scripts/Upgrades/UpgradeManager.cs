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

    public Upgrade GetRandomUpgrade()
    {
        return upgrades[Random.Range(0, upgrades.Length)];
    }
}
