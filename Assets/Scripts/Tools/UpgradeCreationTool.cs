using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UpgradeCreationTool : EditorWindow
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
        GUILayout.Label("Upgrade Creation Tool", EditorStyles.boldLabel);
        
        GUILayout.BeginHorizontal();
        upgradeName = EditorGUILayout.TextField("Name", upgradeName);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        upgradeDescription = EditorGUILayout.TextField("Description", upgradeDescription);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        type = (Type) EditorGUILayout.EnumPopup("Upgrade type", type);
        GUILayout.EndHorizontal();

        switch (type)
        {
            case Type.MaxHealth:
                GUILayout.BeginHorizontal();
                increase = EditorGUILayout.IntField("Max Health Increase", increase);
                GUILayout.EndHorizontal();
                break;
            case Type.Speed:
                GUILayout.BeginHorizontal();
                increase = EditorGUILayout.IntField("Speed Increase", increase);
                GUILayout.EndHorizontal();
                break;
            case Type.GiveWeapon:
                GUILayout.BeginHorizontal();
                weapon = (GameObject)EditorGUILayout.ObjectField("Weapon prefab", weapon, typeof(GameObject), true);
                GUILayout.EndHorizontal();
                break;
            case Type.UpgradeWeapon:
                GUILayout.BeginHorizontal();
                weapon = (GameObject)EditorGUILayout.ObjectField("Weapon prefab", weapon, typeof(GameObject), true);
                GUILayout.EndHorizontal();
                
                GUILayout.BeginHorizontal();
                prerequisiteUpgrade = (Upgrade)EditorGUILayout.ObjectField("Prerequisite Upgrade", prerequisiteUpgrade, typeof(Upgrade), true);
                GUILayout.EndHorizontal();
                
                GUILayout.BeginHorizontal();
                maxUpgradeCount = EditorGUILayout.IntField("Max Upgrade Count", maxUpgradeCount);
                GUILayout.EndHorizontal();
                break;
        }

        if (GUILayout.Button("Create Upgrade"))
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
        
        if (success)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Upgrade Created Successfully!", EditorStyles.boldLabel);
        }
    }
}
