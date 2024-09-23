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

    private void OnEnable()
    {
        ExperienceManager.onLevelUp += OnLevelUp;
    }
    
    private void OnDisable()
    {
        ExperienceManager.onLevelUp -= OnLevelUp;
    }

    private void OnLevelUp()
    {
        int index = Random.Range(0, upgrades.Length);
        upgrades[index].Apply(player.gameObject);
    }
}
