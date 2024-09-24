using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Upgrades/MaxHealthUpgrade")]
public class MaxHealthUpgrade : Upgrade
{
    [SerializeField] private int increaseAmount;
    
    public override void Apply(GameObject target)
    {
        Health health = target.GetComponentInParent<Health>();
        health.IncreaseMaxHealth(increaseAmount);
        health.Heal(increaseAmount);
    }
}
