using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Upgrades/WeaponUpgrade")]
public class UpgradeSpecificWeapon : Upgrade
{
    public GameObject weapon;
        
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent<WeaponManager>(out WeaponManager weaponManager))
        {
            weaponManager.FindWeapon(weapon);
        }
    }
}
