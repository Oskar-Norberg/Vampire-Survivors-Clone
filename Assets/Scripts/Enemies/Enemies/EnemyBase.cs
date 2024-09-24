using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : PausableMonoBehaviour
{
    [SerializeField] private EnemyData data;
    
    [SerializeField] private Animator animator;
    [SerializeField] private FlipSprite flipSprite;
    
    private new Rigidbody2D rigidbody2D;
    private Attack attackComponent;
    private Transform targetTransform;

    private Vector2 prePauseVelocity;
    
    public delegate void OnEnenmyDeathDelegate(EnemyBase enemy);
    public static event OnEnenmyDeathDelegate onEnemyDeath;
    
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

    public void PathFind()
    {
        if (!targetTransform) return;
        
        Vector2 rigidbodyPosition = rigidbody2D.position;
        Vector2 targetPosition = targetTransform.position;

        Vector2 wishDir = data.strategy.PathFind(rigidbodyPosition, targetPosition);

        wishDir *= data.moveSpeed;
        
        rigidbody2D.AddForce(wishDir, ForceMode2D.Force);
    }

    private void OnDestroy()
    {
        onEnemyDeath?.Invoke(this);
    }

    public override void Pause()
    {
        prePauseVelocity = rigidbody2D.velocity;
        animator.enabled = false;
        flipSprite.enabled = false;
        rigidbody2D.velocity = Vector2.zero;
    }

    public override void UnPause()
    {
        rigidbody2D.velocity = prePauseVelocity;
        animator.enabled = true;
        flipSprite.enabled = true;
    }
}
