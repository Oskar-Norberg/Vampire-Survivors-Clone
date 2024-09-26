using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int health;

    public int damage;
    
    public float moveSpeed;
    
    public IAIStrategy strategy;
}
