using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Upgrades/Weapons/MagicSpell")]
public class UpgradeMagicSpell : UpgradeSpecificWeapon
{
    protected override void Upgrade(WeaponBase weapon)
    {
        MagicSpellSpawner spell = null;
        if (weapon is MagicSpellSpawner spellSpawner)
        {
            spell = spellSpawner;
        }

        if (!spell)
        {
            Debug.Log("Upgrade MagicSpell: Magic Spell not found");
            return;
        }
        
        spell.IncreaseSpellCount();
    }
}
