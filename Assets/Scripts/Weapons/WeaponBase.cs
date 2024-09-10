using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private float cooldownMilliseconds;
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
        yield return new WaitForSeconds(cooldownMilliseconds / 1000);
        State = WeaponStates.Ready;
    }
}
