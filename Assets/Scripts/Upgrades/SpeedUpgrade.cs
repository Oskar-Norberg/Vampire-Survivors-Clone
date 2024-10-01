using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Upgrades/SpeedUpgrade")]
public class SpeedUpgrade : Upgrade
{
    public float speedIncreasePercent;
    
    public override void Apply(GameObject target)
    {
        float rateOfChange = 1.0f + speedIncreasePercent / 100.0f;
        target.GetComponentInParent<PlayerController>().IncreaseSpeed(rateOfChange);
    }
}
