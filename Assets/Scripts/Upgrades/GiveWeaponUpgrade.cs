using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveWeaponUpgrade : Upgrade
{
    public GameObject weapon;
    public override void Apply(GameObject target)
    {
        WeaponManager weaponManager = target.GetComponent<WeaponManager>();
        weaponManager.AddWeapon(weapon);
    }
}
