using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Attack attackComponent;

    private enum WeaponStates {Ready, OnCooldown}

    private WeaponStates state = WeaponStates.Ready;
    
    private void Start()
    {
        spriteRenderer.sprite = weaponData.sprite;
        
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        switch (weaponData.attackType)
        {
            case AttackType.Melee:
                attackComponent.SetDamage(weaponData.damage);
                boxCollider2D.size = weaponData.hitboxSize;
                boxCollider2D.transform.position = weaponData.hitboxPosition;
                break;
        }
    }

    private void FixedUpdate()
    {
        UpdatePosition();
        
        if (state == WeaponStates.OnCooldown) return;

        switch (weaponData.attackType)
        {
            case AttackType.Melee:
                state = WeaponStates.OnCooldown;
                StartCoroutine(MeleeAttack());
                break;
        }
    }

    private IEnumerator MeleeAttack()
    {
        boxCollider2D.enabled = true;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(weaponData.attackDurationMilliseconds / 1000);
        boxCollider2D.enabled = false;
        spriteRenderer.enabled = false;
        StartCoroutine(StartCooldown());
    }
    
    private IEnumerator StartCooldown()
    {
        state = WeaponStates.OnCooldown;
        yield return new WaitForSeconds(weaponData.cooldownTimeMilliseconds / 1000);
        state = WeaponStates.Ready;
    }

    private void UpdatePosition()
    {
        // Implement position code for weapon here:
    }
}
