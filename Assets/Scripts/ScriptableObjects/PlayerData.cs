using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public int health;
    public float moveSpeed;
    public GameObject startWeapon;
}
