using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UpgradeCreationTool : CreationToolBase
{
    private const string UPGRADE_PATH = "Assets/Resources/ScriptableObjects/Upgrades";
    
    private string upgradeName;
    private string upgradeDescription;

    // Stat-increase
    private int increase;
    
    // Give Weapon, WeaponUpgrade
    private GameObject weapon;
    
    // WeaponUpgrade
    private Upgrade prerequisiteUpgrade;
    private int maxUpgradeCount;
    
    private enum Type {MaxHealth, Speed, GiveWeapon, UpgradeWeapon}
    private Type type;

    private bool success = false;
    
    [MenuItem("Tools/Upgrade Creation")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<UpgradeCreationTool>("Upgrade Creation Tool");
    }
    
    private void OnGUI()
    {
        BoldLabel("Upgrade Creation Tool");
        
        EditorGUILayout.Space();
        
        TextField("Name", ref upgradeName);
        TextField("Description", ref upgradeDescription);
        
        EditorGUILayout.Space();
        
        EnumPopup("Upgrade type", ref type);

        switch (type)
        {
            case Type.MaxHealth:
                IntField("Max Health Increase", ref increase);
                break;
            case Type.Speed:
                IntField("Speed Increase", ref increase);
                break;
            case Type.GiveWeapon:
                ObjectDropdown("Weapon Prefab", ref weapon);
                break;
            case Type.UpgradeWeapon:
                ObjectDropdown("Weapon Prefab", ref weapon);
                ObjectDropdown("Upgrade Prefab", ref prerequisiteUpgrade);
                IntField("Max Upgrade Count", ref maxUpgradeCount);
                break;
        }
        
        EditorGUILayout.Space();

        if (ButtonField("Create Upgrade"))
        {
            CreateUpgrade();
        }
        
        if (success)
        {
            EditorGUILayout.Space();
            BoldLabel("Upgrade Created Successfully!");
        }
    }

    private void CreateUpgrade()
    {
        Upgrade asset = null;
            
        switch (type)
        { 
            case Type.MaxHealth:
                asset = ScriptableObject.CreateInstance<MaxHealthUpgrade>();
                MaxHealthUpgrade maxHealth = asset as MaxHealthUpgrade;
                if (maxHealth)
                {
                    maxHealth.increaseAmount = increase;
                }
                break;
                
            case Type.Speed:
                asset = ScriptableObject.CreateInstance<SpeedUpgrade>();
                SpeedUpgrade speed = asset as SpeedUpgrade;
                if (speed)
                {
                    speed.speedIncreasePercent = increase;
                }
                break;
            case Type.GiveWeapon:
                asset = ScriptableObject.CreateInstance<GiveWeaponUpgrade>();
                GiveWeaponUpgrade giveWeapon = asset as GiveWeaponUpgrade;
                if (giveWeapon)
                {
                    giveWeapon.weapon = weapon;
                }
                break;
            case Type.UpgradeWeapon:
                asset = ScriptableObject.CreateInstance<WeaponUpgrade>();
                WeaponUpgrade weaponUpgrade = asset as WeaponUpgrade;
                if (weaponUpgrade)
                {
                    weaponUpgrade.weapon = weapon;
                    weaponUpgrade.prerequisiteUpgrade = prerequisiteUpgrade;
                    weaponUpgrade.maxUpgradeCount = maxUpgradeCount;
                }
                break;
            default:
                Debug.Log("UpgradeCreationTool: Unknown Upgrade type");
                break;
        }

        // Universal upgrade parameters
        if (asset)
        {
            asset.name = upgradeName;
            asset.description = upgradeDescription;
            Debug.Log(UPGRADE_PATH + "/" + upgradeName.Trim(' ').Trim() + ".asset");
            AssetDatabase.CreateAsset(asset, UPGRADE_PATH + "/" + upgradeName.Trim(' ').Trim() + ".asset");
            success = true;
        }
    }
}
