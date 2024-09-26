using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Upgrades/WeaponUpgrade")]
public class WeaponUpgrade : Upgrade
{
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent<WeaponManager>(out WeaponManager weaponManager))
        {
            weaponManager.UpgradeRandomWeapon();
        }
    }
}
