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

    public void UpgradeWeapon(GameObject weapon)
    {
        WeaponBase foundWeapon = null;
        
        Type weaponType = weapon.GetComponent<WeaponBase>().GetType();
        
        foreach (WeaponBase playerWeapon in weapons)
        {
            Type playerWeaponType = playerWeapon.GetType();
            if (weaponType == playerWeaponType)
            {
                foundWeapon = playerWeapon;
                break;
            }
        }

        if (foundWeapon)
        {
            foundWeapon.Upgrade();
        }
        else
        {
            AddWeapon(weapon);
        }
    }

    public void UpgradeRandomWeapon()
    {
        int index = Random.Range(0, weapons.Count);
        weapons[index].Upgrade();
    }
}
