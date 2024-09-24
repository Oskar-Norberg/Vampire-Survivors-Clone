using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : PausableMonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    [SerializeField] private Animator animator;
    [SerializeField] private RegenerateHealth regenerateHealth;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private FlipSprite flipSprite;
    
    private Vector2 speedMultiplier = Vector2.one;
    
    private new Rigidbody2D rigidbody;
    private PlayerInput playerInput;

    private Vector2 prePauseVelocity;

    private void Start()
    {
        weaponManager.AddWeapon(playerData.startWeapon);
        
        rigidbody = GetComponent<Rigidbody2D>();
        
        playerInput = GetComponent<PlayerInput>();
        
        if (TryGetComponent<Health>(out Health health))
        {
            health.SetHealth(playerData.health);
        }
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("Velocity", Mathf.Abs(rigidbody.velocity.magnitude));
    }

    private void FixedUpdate()
    {
        if (IsPaused) return;
        UpdateRigidbody();
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
        rigidbody.AddForce(wishDir * playerData.moveSpeed * speedMultiplier, ForceMode2D.Force);
    }

    public void IncreaseSpeed(float rateOfChange)
    {
        speedMultiplier *= rateOfChange;
    }

    protected override void Pause()
    {
        base.Pause();
        prePauseVelocity = rigidbody.velocity;
        flipSprite.enabled = false;
        rigidbody.velocity = Vector2.zero;
    }

    protected override void UnPause()
    {
        base.UnPause();
        rigidbody.velocity = prePauseVelocity;
        flipSprite.enabled = true;
    }
}
