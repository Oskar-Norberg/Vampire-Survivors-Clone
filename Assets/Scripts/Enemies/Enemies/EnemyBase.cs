using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : PausableMonoBehaviour
{
    [Header("Data")]
    [SerializeField] private EnemyData data;
    
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private FlipSprite flipSprite;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private TickCooldownAttack attack;
    [SerializeField] private Health health;
    
    private Transform targetTransform;

    private Vector2 prePauseVelocity;
    
    public delegate void OnEnemyDeathDelegate(EnemyBase enemy);
    public static event OnEnemyDeathDelegate onEnemyDeath;
    
    private void Start()
    {
        health.SetHealth(data.health);
        attack.SetDamage(data.damage);
        attack.SetTickCooldown(data.tickCooldownMilliseconds);
        
        // TODO Avoid using FindGameObject
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        targetTransform = player.transform;
    }

    private void FixedUpdate()
    {
        if (!targetTransform || IsPaused) return;
        
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

    protected override void Pause()
    {
        base.Pause();
        prePauseVelocity = rigidbody2D.velocity;
        animator.enabled = false;
        flipSprite.enabled = false;
        rigidbody2D.velocity = Vector2.zero;
    }

    protected override void UnPause()
    {
        base.UnPause();
        rigidbody2D.velocity = prePauseVelocity;
        animator.enabled = true;
        flipSprite.enabled = true;
    }
}
