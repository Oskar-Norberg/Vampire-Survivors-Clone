using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnStay : Attack
{
    private void OnTriggerStay2D(Collider2D other)
    {
        // Try to get health component in parent and apply attack damage
        if (other.transform.parent.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
    }
}
