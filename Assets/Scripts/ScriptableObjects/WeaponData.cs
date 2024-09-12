using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public new string name;

    public float cooldownTimeMilliseconds;
    public float attackDurationMilliseconds;

    public int damage;
}
