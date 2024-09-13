using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private IAIStrategy strategy;
    
    private Rigidbody2D _rigidbody2D;
    private Attack _attackComponent;
    private Transform _playerTransform;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        if (TryGetComponent<Attack>(out Attack attack))
        {
            attack.SetDamage(data.damage);
        }
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        _playerTransform = player.transform;
    }

    void FixedUpdate()
    {
        PathFind();
    }

    private void PathFind()
    {
        if (!_playerTransform) return;
        
        Vector2 rigidbodyPosition = _rigidbody2D.position;
        Vector2 targetPosition = _playerTransform.position;

        Vector2 wishDir = strategy.PathFind(rigidbodyPosition, targetPosition);

        wishDir *= data.moveSpeed;
        
        _rigidbody2D.AddForce(wishDir, ForceMode2D.Force);
    }
}
