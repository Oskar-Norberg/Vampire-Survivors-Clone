using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private int damage = 1;
    
    private Rigidbody2D _rigidbody2D;
    private Transform _playerTransform;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        PathFind();
    }

    // Manhattan Path-finding
    private void PathFind()
    {
        Vector2 wishDir = new Vector2(_playerTransform.position.x - _rigidbody2D.position.x, _playerTransform.position.y - _rigidbody2D.position.y);
        wishDir = Vector2.ClampMagnitude(wishDir, 1.0f);
        wishDir *= moveSpeed;
        _rigidbody2D.AddForce(wishDir, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        other.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
    }
}
