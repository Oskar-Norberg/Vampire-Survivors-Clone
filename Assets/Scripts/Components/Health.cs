using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    private int maxHealth;
    
    public delegate void OnHealthChange();
    public static OnHealthChange onHealthChange;

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
    
    public void TakeDamage(int damage)
    {
        print(gameObject.name + " Took damage!");
        onHealthChange?.Invoke();
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Health reached 0");
        Destroy(gameObject);
        throw new NotImplementedException();
    }
}
