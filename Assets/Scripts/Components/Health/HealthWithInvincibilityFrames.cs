using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWithInvincibilityFrames : Health
{
    private int invincibilityTimeMilliseconds;
    private bool justDamaged = false;
    private float timer = 0.0f;
    
    public void SetInvincibilityTime(int invincibilityTimeMilliseconds)
    {
        this.invincibilityTimeMilliseconds = invincibilityTimeMilliseconds;
    }
    
    public override void TakeDamage(int damage)
    {
        if (justDamaged) return;

        justDamaged = true;
        health -= damage;
        CallOnHealthChange();
        CallOnDamageTaken();
        if (health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (IsPaused || !justDamaged) return;

        timer += Time.deltaTime;

        if (timer >= invincibilityTimeMilliseconds / 1000.0f)
        {
            timer = 0.0f;
            justDamaged = false;
        }
    }
}
