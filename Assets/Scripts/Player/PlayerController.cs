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
    
    private new Rigidbody2D rigidbody;
    private PlayerInput playerInput;

    private void Start()
    {
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

    public void FixedUpdateMovement()
    {
        if (!rigidbody)
        {
            Debug.Log("Player Rigidbody is null");
            return;
        }
        Vector2 wishDir = playerInput.GetWishDir().normalized;
        rigidbody.AddForce(wishDir * playerData.moveSpeed, ForceMode2D.Force);
    }
}
