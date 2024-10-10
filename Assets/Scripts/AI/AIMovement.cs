using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIMovement : ScriptableObject
{
    public abstract Vector2 PathFind(Vector2 position, Vector2 targetPosition);
}
