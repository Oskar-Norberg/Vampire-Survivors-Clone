using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicSpellSpawner : WeaponBase
{
    [SerializeField] private GameObject magicSpellPrefab;

    [Header("Magic Spell Settings")] 
    [SerializeField] private float velocity;

    private float timer = 0.0f;

    private GameObject[] spells = new GameObject[4];

    private void Start()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = Instantiate(magicSpellPrefab, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= weaponData.cooldownTimeMilliseconds / 1000.0f)
        {
            SpawnMagicSpell();
        }
    }

    private void SpawnMagicSpell()
    {
        if (spells == null) return;

        GameObject spell = spells[upgrade];
        
        spell.transform.position = transform.position;
        spell.SetActive(true);
        
        Vector2 force = Vector2.right * velocity;
        spell.GetComponent<Rigidbody2D>().AddForce(force);

        timer = 0.0f;
    }

    protected override void UpgradeOne()
    {
        throw new NotImplementedException();
    }

    protected override void UpgradeTwo()
    {
        throw new NotImplementedException();
    }

    protected override void UpgradeThree()
    {
        throw new NotImplementedException();
    }
}
