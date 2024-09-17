using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSpriteOnHit : MonoBehaviour
{
    [SerializeField] private float blinkDurationMilliseconds = 250.0f;

    [SerializeField] private Color blinkColor = Color.red;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Health health;

    private bool coroutineRunning = false;

    private void BlinkSprite()
    {
        print("blink sprite");
        if (!spriteRenderer || !health) return;
        StartCoroutine(BlinkSpriteCoroutine());
    }

    private IEnumerator BlinkSpriteCoroutine()
    {
        if (coroutineRunning) yield break;
        coroutineRunning = true;
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkDurationMilliseconds / 1000);
        spriteRenderer.color = originalColor;
        coroutineRunning = false;
    }

    private void OnEnable()
    {
        if (!health) return;
        health.onDamageTaken += BlinkSprite;
    }

    private void OnDisable()
    {
        if (!health) return;
        health.onDamageTaken -= BlinkSprite;
    }
}
