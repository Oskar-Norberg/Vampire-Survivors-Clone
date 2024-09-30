using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class UpgradeSpecificWeapon : Upgrade
{
    public GameObject weaponPrefab;
    
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent<WeaponManager>(out WeaponManager weaponManager))
        {
            WeaponBase weapon = weaponManager.FindWeapon(weaponPrefab);
            
            if (!weapon)
            {
                weaponManager.AddWeapon(weaponPrefab);
            }
            else
            {
                Upgrade(weapon);
            }
        }
    }

    protected abstract void Upgrade(WeaponBase weapon);
}
