using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    private int maxHealth;
    
    public delegate void OnHealthChange();
    public event OnHealthChange onHealthChange;
    
    public delegate void OnDamageTaken();
    public event OnDamageTaken onDamageTaken;

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    
    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        maxHealth = health;
        this.health = health;
    }
    
    public void Heal(int health)
    {
        this.health += health;
        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
        onHealthChange?.Invoke();
    }
    
    public void TakeDamage(int damage)
    {
        print(gameObject.name + " Took damage!");
        health -= damage;
        onHealthChange?.Invoke();
        onDamageTaken?.Invoke();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Health reached 0");
        Destroy(gameObject);
    }
}
