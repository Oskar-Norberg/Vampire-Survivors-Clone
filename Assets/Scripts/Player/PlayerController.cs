using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    private Rigidbody2D _rigidbody;

    private Vector2 _wishDir;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        _rigidbody.AddForce(_wishDir * movementSpeed, ForceMode2D.Force);
    }
}
