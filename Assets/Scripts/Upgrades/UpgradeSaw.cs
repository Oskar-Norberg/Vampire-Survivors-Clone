using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Upgrades/Weapons/Saw")]

public class UpgradeSaw : UpgradeSpecificWeapon
{
    protected override void Upgrade(WeaponBase weapon)
    {
        OrbitingSaw saw = null;
        if (weapon is OrbitingSaw orbitingSaw)
        {
            saw = orbitingSaw;
        }

        if (!saw)
        {
            Debug.Log("Upgrade Saw: Saw not found");
            return;
        }
        
        saw.AddSaw();
    }
}
