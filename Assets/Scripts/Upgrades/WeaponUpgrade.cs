using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : PrerequisiteUpgrade
{
    public GameObject weapon;

    public int maxUpgradeCount;
    
    public override void Apply(GameObject target)
    {
        WeaponManager weaponManager = target.GetComponent<WeaponManager>();
        WeaponBase weaponBase = weaponManager.FindWeapon(weapon);
        weaponBase.Upgrade();
    }
}
