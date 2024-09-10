using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attack Properties")]
    [SerializeField] private int damage = 1;
    
    [Header("Tags to Attack")]
    [SerializeField] private bool attackPlayer;
    [SerializeField] private bool attackEnemy;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Attack if collision tag matches attack specified tags
        bool attack = other.CompareTag("Player") && attackPlayer || other.CompareTag("Enemy") && attackEnemy;

        if (!attack) return;

        // Try to get health component in parent and apply attack damage
        if (other.transform.parent.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
    }
}
