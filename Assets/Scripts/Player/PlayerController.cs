using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    private Rigidbody2D _rigidbody;
    private Vector2 _wishDir;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if (TryGetComponent<Health>(out Health health))
        {
            health.SetHealth(playerData.health);
        }
    }

    private void Update()
    {
        _wishDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _wishDir.Normalize();
        _rigidbody.AddForce(_wishDir * playerData.moveSpeed, ForceMode2D.Force);
    }
}
