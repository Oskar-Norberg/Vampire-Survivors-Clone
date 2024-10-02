using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTrigger : PausableMonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed;
    [SerializeField] private AIMovement aiMovement;
    
    private Transform target;

    private Vector2 prePauseVelocity;

    private void Start()
    {
        aiMovement.SetType(AIMovement.AIType.MoveTowards);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        target = other.transform;
    }

    private void FixedUpdate()
    {
        if (!rigidbody || !target || IsPaused) return;

        Vector2 wishDir = aiMovement.PathFind(transform.position, target.position);
        
        rigidbody.AddForce(wishDir * movementSpeed);
    }

    protected override void Pause()
    {
        base.Pause();
        prePauseVelocity = rigidbody.velocity;
        rigidbody.velocity = Vector2.zero;
    }

    protected override void UnPause()
    {
        base.UnPause();
        rigidbody.velocity = prePauseVelocity;
    }
}
