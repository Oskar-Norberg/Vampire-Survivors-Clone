using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsAI : IAIStrategy
{
    [SerializeField] private float oscillationSpeed = 1.0f;
    [SerializeField] private float oscillationAmplitude = 1.0f;
    
    public override Vector2 PathFind(Vector2 position, Vector2 targetPosition)
    {
        Vector2 wishDir = targetPosition - position;

        Vector2 perpendicularDir = new Vector2(-wishDir.y, wishDir.x);

        float oscillationMagnitude = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmplitude;
        wishDir += perpendicularDir * oscillationMagnitude;

        return wishDir.normalized;
    }
}
