using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    private new Rigidbody2D rigidbody;
    private Vector2 wishDir;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
        if (TryGetComponent<Health>(out Health health))
        {
            health.SetHealth(playerData.health);
        }
    }

    private void Update()
    {
        wishDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        wishDir.Normalize();
        rigidbody.AddForce(wishDir * playerData.moveSpeed, ForceMode2D.Force);
    }
}
