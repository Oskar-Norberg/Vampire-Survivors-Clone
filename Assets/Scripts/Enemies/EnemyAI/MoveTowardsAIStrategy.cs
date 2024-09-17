using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsAIStrategy : IAIStrategy
{
    public override Vector2 PathFind(Vector2 position, Vector2 targetPosition)
    {
        float distanceToPlayer = Vector2.Distance(position, targetPosition);

        Vector2 wishDir = targetPosition - position;
        return Vector2.ClampMagnitude(wishDir, 1.0f);
    }
}
