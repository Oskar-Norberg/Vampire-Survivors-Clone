using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lasso : WeaponBase
{
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator animator;
    [SerializeField] private Attack attackComponent;
    
    private void Start()
    {
        SetAttackStatus(false);
        attackComponent.SetDamage(weaponData.damage);
    }

    protected void Activate()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        SetAttackStatus(true);
        yield return new WaitForSeconds(weaponData.attackDurationMilliseconds / 1000);
        SetAttackStatus(false);
        StartCoroutine(StartCooldown());
    }
    
    protected IEnumerator StartCooldown()
    {
        State = WeaponStates.OnCooldown;
        yield return new WaitForSeconds(weaponData.cooldownTimeMilliseconds / 1000);
        State = WeaponStates.Ready;
    }

    private void SetAttackStatus(bool status)
    {
        animator.SetBool("PlayAnimation", status);
        sprite.enabled = status;
        hitbox.enabled = status;
    }

    public override void FixedUpdateMovement()
    {
        
    }
}
