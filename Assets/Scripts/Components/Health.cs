using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startHealth = 5;

    private int _health;
    
    void Start()
    {
        _health = startHealth;
    }
    
    public void TakeDamage(int damage)
    {
        print("Player took damage!");
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
