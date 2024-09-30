using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponManager : MonoBehaviour
{
    private List<WeaponBase> weapons = new List<WeaponBase>();
    
    public void AddWeapon(GameObject weapon)
    {
        GameObject instance = Instantiate(weapon, transform);
        weapons.Add(instance.GetComponent<WeaponBase>());
    }

    public WeaponBase FindWeapon(GameObject weapon)
    {
        Type weaponType = weapon.GetComponent<WeaponBase>().GetType();

        foreach (WeaponBase playerWeapon in weapons)
        {
            Type playerWeaponType = playerWeapon.GetType();
            if (weaponType == playerWeaponType)
            {
                return playerWeapon;
            }
        }

        return null;
    }
}
