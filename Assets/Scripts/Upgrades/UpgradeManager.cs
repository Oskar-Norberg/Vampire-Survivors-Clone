using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private const string UpgradePath = "ScriptableObjects/Upgrades";
    
    private Upgrade[] upgrades;

    private void Start()
    {
        upgrades = Resources.LoadAll<Upgrade>(UpgradePath);
    }
}
