using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : PausableMonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerData playerData;
    
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private RegenerateHealth regenerateHealth;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private FlipSprite flipSprite;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] private PlayerInput playerInput;
    
    // Modifiers
    private Vector2 speedMultiplier = Vector2.one;

    // Pausing
    private Vector2 prePauseVelocity;

    private void Start()
    {
        weaponManager.AddWeapon(playerData.startWeapon);
        
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
