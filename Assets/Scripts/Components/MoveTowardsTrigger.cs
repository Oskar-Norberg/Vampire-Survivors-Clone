using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTrigger : PausableMonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed;
    [SerializeField] private IAIStrategy strategy;
    
    private Transform target;

    private bool isPaused = false;
    private Vector2 prePauseVelocity;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        target = other.transform;
    }

    private void FixedUpdate()
    {
        if (!rigidbody || !target || isPaused) return;

        Vector2 wishDir = strategy.PathFind(transform.position, target.position);
        
        rigidbody.AddForce(wishDir * movementSpeed);
    }

    protected override void Pause()
    {
        isPaused = true;
        prePauseVelocity = rigidbody.velocity;
        rigidbody.velocity = Vector2.zero;
    }

    protected override void UnPause()
    {
        isPaused = false;
        rigidbody.velocity = prePauseVelocity;
    }
}
