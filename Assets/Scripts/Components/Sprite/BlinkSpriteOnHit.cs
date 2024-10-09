using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSpriteOnHit : PausableMonoBehaviour
{
    [SerializeField] private Health health;
    
    [SerializeField] private float blinkDurationMilliseconds = 250.0f;
    [SerializeField] private Material blinkMaterial;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private bool coroutineRunning = false;
    private enum BlinkState {NotBlinking, BlinkStart, Blinking}
    private BlinkState blinkState = BlinkState.NotBlinking;

    private void BlinkSprite()
    {
        if (!spriteRenderer || !health) return;
        StartCoroutine(BlinkSpriteCoroutine());
    }

    private void Update()
    {
        if (IsPaused || blinkState == BlinkState.NotBlinking) return;
        
        timer += Time.deltaTime;

        if (blinkState == BlinkState.BlinkStart)
        {
            blinkState = BlinkState.Blinking;
            originalMaterial = spriteRenderer.material;
            spriteRenderer.material = blinkMaterial;
        }

        if (!(timer >= blinkDurationMilliseconds / 1000)) return;
        
        blinkState = BlinkState.NotBlinking;
        timer = 0.0f;
        spriteRenderer.material = originalMaterial;
        originalMaterial = null;
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
