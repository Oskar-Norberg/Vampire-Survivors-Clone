using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PausableMonoBehaviour
{
    [Header("Attack Properties")]
    private int damage = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try to get health component in parent and apply attack damage
        if (other.transform.parent.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
    }
    
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
