using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class IAIStrategy : MonoBehaviour
{
    public abstract Vector2 PathFind(Vector2 position, Vector2 targetPosition);
}