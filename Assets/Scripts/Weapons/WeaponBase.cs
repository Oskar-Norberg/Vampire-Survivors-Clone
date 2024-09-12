using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    protected enum WeaponStates {Ready, OnCooldown}

    protected WeaponStates State = WeaponStates.Ready;
}
