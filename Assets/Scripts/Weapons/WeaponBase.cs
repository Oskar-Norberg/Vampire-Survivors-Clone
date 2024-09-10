using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldownTime;
    
    private enum WeaponState {Ready, OnCooldown}
    private WeaponState _state;

    private float _cooldownTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        _state = WeaponState.Ready;
        _cooldownTimer = 0.0f;
    }

    private void FixedUpdate()
    {
        TickCooldownTimer();
        Attack();
    }

    protected abstract void Attack();

    private void TickCooldownTimer()
    {
        if (_state != WeaponState.OnCooldown)
            return;
        
        _cooldownTimer += Time.deltaTime;

        if (!(_cooldownTimer >= cooldownTime)) return;
        
        _state = WeaponState.Ready;
        _cooldownTimer = 0.0f;
    }
}
