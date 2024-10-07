using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PausableMonoBehaviour
{
    protected int health;
    protected int maxHealth;
    
    public delegate void OnHealthChange();
    public event OnHealthChange onHealthChange;
    
    public delegate void OnDamageTaken();
    public event OnDamageTaken onDamageTaken;
    
    public delegate void OnDeathDelegate();
    public event OnDeathDelegate onDeath;


    public int GetMaxHealth()
    {
        return maxHealth;
    }
    
    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        maxHealth = newHealth;
        this.health = newHealth;
    }
    
    public void Heal(int newHealth)
    {
        this.health += newHealth;
        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
        onHealthChange?.Invoke();
    }
    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        onHealthChange?.Invoke();
        onDamageTaken?.Invoke();
        if (health <= 0)
        {
            Die();
        }
    }
    
    public void IncreaseMaxHealth(int increase)
    {
        maxHealth += increase;
        onHealthChange?.Invoke();
    }

    protected void Die()
    {
        onDeath?.Invoke();
        Destroy(gameObject);
    }

    protected void CallOnHealthChange()
    {
        onHealthChange?.Invoke();
    }

    protected void CallOnDamageTaken()
    {
        onDamageTaken?.Invoke();
    }
}
