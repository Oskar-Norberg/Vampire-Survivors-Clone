using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnStayCooldown : Attack
{
    private int tickCooldownMilliseconds = 0;
    private float cooldownTimer = 0.0f;
    private bool ready = true;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!ready) return;
        
        // Try to get health component in parent and apply attack damage
        if (other.transform.parent.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
            ready = false;
        }
    }

    private void FixedUpdate()
    {
        if (IsPaused || ready) return;
        
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= tickCooldownMilliseconds / 1000.0f)
        {
            ready = true;
            cooldownTimer = 0.0f;
        }
    }
    
    public void SetTickCooldown(int tickCooldownMilliseconds)
    {
        this.tickCooldownMilliseconds = tickCooldownMilliseconds;
    }
}
