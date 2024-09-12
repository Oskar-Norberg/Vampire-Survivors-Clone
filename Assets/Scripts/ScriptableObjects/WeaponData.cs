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
    public new string Name;
    public Sprite Sprite;
    
    public int Damage;
    public float CooldownTimeMilliseconds;

    public AttackType AttackType;

    public float AttackDurationMilliseconds;
    public Vector2 HitboxSize;
    public Vector2 HitboxPosition;
    
    public GameObject ProjectilePrefab;

    public Positioning Positioning;

    public PositioningTarget PositioningTarget;
}
