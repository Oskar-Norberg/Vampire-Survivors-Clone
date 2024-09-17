using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Regen Data")]
public class RegenData : ScriptableObject
{
    public float millisecondsPerRegen;
    public int healthPerTick;
}
