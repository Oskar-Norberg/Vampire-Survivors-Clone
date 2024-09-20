using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    [SerializeField] private Animator animator;
    [SerializeField] private RegenerateHealth regenerateHealth;

    
    private new Rigidbody2D rigidbody;
    private PlayerInput playerInput;

    private List<WeaponBase> weapons = new List<WeaponBase>();

    private void Start()
    {
        AddWeapon(playerData.startWeapon);
        
        rigidbody = GetComponent<Rigidbody2D>();
        
        playerInput = GetComponent<PlayerInput>();
        
        if (TryGetComponent<Health>(out Health health))
        {
            health.SetHealth(playerData.health);
        }
    }

    private void AddWeapon(GameObject weapon)
    {
        GameObject instance = Instantiate(weapon, transform);
        weapons.Add(instance.GetComponent<WeaponBase>());
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("Velocity", Mathf.Abs(rigidbody.velocity.magnitude));
    }

    public void FixedUpdatePlayer()
    {
        UpdateRigidbody();
        UpdateWeapons();
        regenerateHealth.FixedUpdateRegenerate();
    }

    private void UpdateRigidbody()
    {
        if (!rigidbody)
        {
            Debug.Log("Player Rigidbody is null");
            return;
        }
        
        Vector2 wishDir = playerInput.GetWishDir().normalized;
        rigidbody.AddForce(wishDir * playerData.moveSpeed, ForceMode2D.Force);
    }

    private void UpdateWeapons()
    {
        foreach (WeaponBase weapon in weapons)
        {
            weapon.FixedUpdateMovement();
        }
    }
}
