using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AIMovement/Sinusodial")]
public class AISinusodial : AIMovement
{
    public float oscillationSpeed = 1.0f;
    public float oscillationAmplitude = 1.0f;
    
    public override Vector2 PathFind(Vector2 position, Vector2 targetPosition)
    {
        Vector2 wishDir = targetPosition - position;

        Vector2 perpendicularDir = new Vector2(-wishDir.y, wishDir.x);

        float oscillationMagnitude = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmplitude;
        wishDir += perpendicularDir * oscillationMagnitude;

        return Vector2.ClampMagnitude(wishDir, 1.0f);
    }
}
