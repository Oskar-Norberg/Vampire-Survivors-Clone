using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health;
    
    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }
    
    public void TakeDamage(int damage)
    {
        print(gameObject.name + " Took damage!");
        _health -= damage;
        if (_health <= 0)
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
