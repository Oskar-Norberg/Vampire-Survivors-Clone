using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private int startHealth = 5;
    private Rigidbody2D _rigidbody;

    private Vector2 _wishDir;

    private int health;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        health = startHealth;
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

    public void TakeDamage(int damage)
    {
        print("Player took damage!");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died");
        throw new NotImplementedException();
    }
}
