using System.Collections;
using System.Collections.Generic;
using UnityEngine;

{
    [Header("Attack Properties")]
    protected int damage = 0;
    
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
