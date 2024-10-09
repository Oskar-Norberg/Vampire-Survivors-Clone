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

    private IEnumerator BlinkSpriteCoroutine()
    {
        if (coroutineRunning) yield break;
        coroutineRunning = true;
        Material originalMaterial = spriteRenderer.material;
        spriteRenderer.material = blinkMaterial;
        yield return new WaitForSeconds(blinkDurationMilliseconds / 1000);
        spriteRenderer.material = originalMaterial;
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
