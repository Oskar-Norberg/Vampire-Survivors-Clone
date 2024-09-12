using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lasso : WeaponBase
{
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Attack attackComponent;

    private void Start()
    {
        SetAttackStatus(false);
        attackComponent.SetDamage(weaponData.damage);
    }

    protected override void Activate()
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

    private void SetAttackStatus(bool status)
    {
        sprite.enabled = status;
        hitbox.enabled = status;
    }
}
