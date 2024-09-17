using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSpriteOnHit : MonoBehaviour
{
    [SerializeField] private float blinkDurationMilliseconds = 200.0f;

    [SerializeField] private Color blinkColor = Color.red;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Health health;

    private void BlinkSprite()
    {
        print("blink sprite");
        if (!spriteRenderer || !health) return;
        StartCoroutine(BlinkSpriteCoroutine());
    }

    private IEnumerator BlinkSpriteCoroutine()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkDurationMilliseconds / 1000);
        spriteRenderer.color = originalColor;
    }

    private void OnEnable()
    {
        if (!health) return;
        health.onHealthChange += BlinkSprite;
    }

    private void OnDisable()
    {
        if (!health) return;
        health.onHealthChange -= BlinkSprite;
    }
}
