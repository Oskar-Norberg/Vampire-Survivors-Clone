using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    protected enum WeaponStates {Ready, OnCooldown}

    protected WeaponStates State = WeaponStates.Ready;
    
    private void FixedUpdate()
    {
        if (State == WeaponStates.Ready)
        {
            Activate();
        }
    }

    protected abstract void Activate();

    protected IEnumerator StartCooldown()
    {
        State = WeaponStates.OnCooldown;
        yield return new WaitForSeconds(weaponData.cooldownTimeMilliseconds / 1000);
        State = WeaponStates.Ready;
    }
}
