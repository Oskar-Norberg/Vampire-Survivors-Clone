using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : PausableMonoBehaviour
{
    [Header("Attack Properties")]
    protected int damage = 0;
    
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
