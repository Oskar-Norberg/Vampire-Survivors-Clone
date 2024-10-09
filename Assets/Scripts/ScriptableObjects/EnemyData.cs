using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int health;

    public int damage;
    public int tickCooldownMilliseconds;
    public int invincibilityTimeMilliseconds;

    public AIMovement.AIType aiType;
    public float moveSpeed;

    public XPOrbData xpOrbData;
}
