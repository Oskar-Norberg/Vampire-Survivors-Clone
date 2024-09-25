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
    private Animator[] spellAnimators = new Animator[4];
    private Rigidbody2D[] spellRigidbodies = new Rigidbody2D[4];

    private void Start()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = Instantiate(magicSpellPrefab, transform.position, Quaternion.identity);
            spells[i].SetActive(false);
            spells[i].GetComponent<Attack>().SetDamage(weaponData.damage);
            spellAnimators[i] = spells[i].GetComponent<Animator>();
            spellRigidbodies[i] = spells[i].GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        if (IsPaused) return;
        
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
        spellRigidbodies[upgrade].AddForce(force);
        
        spellAnimators[upgrade].SetTrigger("Activate");

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
