using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AIMovement/MoveTowards")]
public class AIMoveTowards : AIMovement
{
    public override Vector2 PathFind(Vector2 position, Vector2 targetPosition)
    {
        Vector2 wishDir = targetPosition - position;
        return Vector2.ClampMagnitude(wishDir, 1.0f);
    }
}
