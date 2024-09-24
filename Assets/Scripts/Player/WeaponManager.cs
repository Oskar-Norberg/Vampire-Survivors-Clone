using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<WeaponBase> weapons = new List<WeaponBase>();
    
    public void AddWeapon(GameObject weapon)
    {
        GameObject instance = Instantiate(weapon, transform);
        weapons.Add(instance.GetComponent<WeaponBase>());
    }

    public void UpgradeRandomWeapon()
    {
        int index = Random.Range(0, weapons.Count);
        weapons[index].Upgrade();
    }
}
