using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
    }
}
