using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : PausableMonoBehaviour
{
    protected int upgrade = 0;
    
    [SerializeField] protected WeaponData weaponData;
    protected enum WeaponStates {Ready, OnCooldown}

    protected WeaponStates State = WeaponStates.Ready;

    public void Upgrade()
    {
        switch (upgrade)
        {
            case 0:
                UpgradeOne();
                break;
            case 1:
                UpgradeTwo();
                break;
            case 2:
                UpgradeThree();
                break;
            default:
                Debug.Log("Invalid upgrade");
                break;
        }
        upgrade++;
    }
    
    protected abstract void UpgradeOne();
    protected abstract void UpgradeTwo();
    protected abstract void UpgradeThree();
}
