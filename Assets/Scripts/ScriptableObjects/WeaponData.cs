using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public enum AttackType { Melee, Projectile };
public enum PositioningTarget { Player };
public enum Positioning { Orbiting, Stationary };

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    
    public int damage;
    public float cooldownTimeMilliseconds;

    public AttackType attackType;

    public float attackDurationMilliseconds;
    public Vector2 hitboxSize;
    public Vector2 hitboxPosition;
    
    public GameObject projectilePrefab;

    public Positioning positioning;

    public PositioningTarget positioningTarget;
}
