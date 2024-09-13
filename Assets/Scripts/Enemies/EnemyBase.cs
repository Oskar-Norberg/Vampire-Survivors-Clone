using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    
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
        
        float distanceToPlayer = Vector3.Distance(_playerTransform.position, transform.position);

        if (distanceToPlayer < data.chaseDistance)
        {
            Vector2 wishDir = new Vector2(_playerTransform.position.x - _rigidbody2D.position.x, _playerTransform.position.y - _rigidbody2D.position.y);
            wishDir = Vector2.ClampMagnitude(wishDir, 1.0f);
            wishDir *= data.moveSpeed;
            _rigidbody2D.AddForce(wishDir, ForceMode2D.Force);
        }
        else
        {
            float x = Time.time * Mathf.PI * 2f / 5.0f;
            Vector2 wishDir = new Vector2(Mathf.Cos(x), Mathf.Sin(x));
            wishDir = Vector2.ClampMagnitude(wishDir, 1.0f);
            wishDir *= data.moveSpeed;
            _rigidbody2D.AddForce(wishDir, ForceMode2D.Force);
        }
    }
}
