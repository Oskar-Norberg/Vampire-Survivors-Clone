using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTrigger : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed;
    [SerializeField] private IAIStrategy strategy;
    
    private Transform target;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        target = other.transform;
    }

    private void FixedUpdate()
    {
        if (!rigidbody) return;
        if (!target) return;

        Vector2 wishDir = strategy.PathFind(transform.position, target.position);
        
        rigidbody.AddForce(wishDir * movementSpeed);
    }
}
