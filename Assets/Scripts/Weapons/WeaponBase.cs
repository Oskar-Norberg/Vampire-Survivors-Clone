using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected int upgrade = 0;
    
    [SerializeField] protected WeaponData weaponData;
    protected enum WeaponStates {Ready, OnCooldown}

    protected WeaponStates State = WeaponStates.Ready;

    public abstract void FixedUpdateMovement();

    public virtual void Upgrade()
    {
        upgrade++;
    }
}
