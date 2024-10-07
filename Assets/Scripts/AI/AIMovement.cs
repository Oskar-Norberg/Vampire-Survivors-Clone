using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float oscillationSpeed = 1.0f;
    [SerializeField] private float oscillationAmplitude = 1.0f;
    
    public enum AIType{ MoveTowards, Sinusodial }
    private AIType aiType;

    public Vector2 PathFind(Vector2 position, Vector2 targetPosition)
    {
        Vector2 wishDir;
        
        switch (aiType)
        {
            case AIType.MoveTowards:
                wishDir = targetPosition - position;
                return Vector2.ClampMagnitude(wishDir, 1.0f);
            case AIType.Sinusodial:
                wishDir = targetPosition - position;

                Vector2 perpendicularDir = new Vector2(-wishDir.y, wishDir.x);

                float oscillationMagnitude = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmplitude;
                wishDir += perpendicularDir * oscillationMagnitude;

                return wishDir.normalized;
            default:
                Debug.Log("Invalid AI Type");
                return Vector2.zero;
        }
    }

    public void SetType(AIType type)
    {
        this.aiType = type;
    }
}
