using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update()
    {
        spriteRenderer.flipX = !(rigidbody.velocity.x > 0.0f);
    }

    public bool IsFlipped()
    {
        return rigidbody.velocity.x < 0.0f;
    }
}
