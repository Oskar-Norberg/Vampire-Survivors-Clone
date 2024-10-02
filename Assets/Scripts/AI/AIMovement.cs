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
        }
    }

    public void SetType(AIType type)
    {
        this.aiType = type;
}
