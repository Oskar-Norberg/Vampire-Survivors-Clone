using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRigidbodyOnPause : PausableMonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    private Vector2 prePauseVelocity;
    
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
