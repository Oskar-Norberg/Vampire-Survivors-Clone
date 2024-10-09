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
    
    private enum BlinkState {NotBlinking, BlinkStart, Blinking}
    private BlinkState blinkState = BlinkState.NotBlinking;
    private float timer = 0.0f;

    private Material originalMaterial;

    private void BlinkSprite()
    {
        if (!spriteRenderer || !health || blinkState != BlinkState.NotBlinking) return;
        blinkState = BlinkState.BlinkStart;
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

    protected override void OnEnable()
    {
        base.OnEnable();
        if (!health) return;
        health.onDamageTaken += BlinkSprite;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (!health) return;
        health.onDamageTaken -= BlinkSprite;
    }
}
