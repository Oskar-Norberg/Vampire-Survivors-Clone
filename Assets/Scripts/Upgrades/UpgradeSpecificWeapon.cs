using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeSpecificWeapon : Upgrade
{
    public GameObject weaponPrefab;
        
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent<WeaponManager>(out WeaponManager weaponManager))
        {
            Upgrade(weaponManager.FindWeapon(weaponPrefab));
        }
    }

    protected abstract void Upgrade(WeaponBase weapon);
}
