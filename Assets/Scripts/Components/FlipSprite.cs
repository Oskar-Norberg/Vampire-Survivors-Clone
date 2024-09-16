using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.flipX = !(rigidbody.velocity.x > 0.0f);
    }
}
