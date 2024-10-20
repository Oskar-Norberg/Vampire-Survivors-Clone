using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public new String name;
    public String description;
    
    public abstract void Apply(GameObject target);
}
