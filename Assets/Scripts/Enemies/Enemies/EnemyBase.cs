using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private IAIStrategy strategy;
    
    private new Rigidbody2D rigidbody2D;
    private Attack attackComponent;
    private Transform targetTransform;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
        if (TryGetComponent<Health>(out Health health))
        {
            health.SetHealth(data.health);
        }
        
        if (TryGetComponent<Attack>(out Attack attack))
        {
            attack.SetDamage(data.damage);
        }
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        targetTransform = player.transform;
    }

    private void FixedUpdate()
    {
        PathFind();
    }

    private void PathFind()
    {
        if (!targetTransform) return;
        
        Vector2 rigidbodyPosition = rigidbody2D.position;
        Vector2 targetPosition = targetTransform.position;

        Vector2 wishDir = strategy.PathFind(rigidbodyPosition, targetPosition);

        wishDir *= data.moveSpeed;
        
        rigidbody2D.AddForce(wishDir, ForceMode2D.Force);
    }
}
