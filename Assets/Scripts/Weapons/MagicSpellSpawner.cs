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

    private class SpellData
    {
        public GameObject gameObject;
        public Animator animator;
        public Rigidbody2D rigidbody;
    }
    
    private SpellData[] spells = new SpellData[4];

    private void Start()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = new SpellData();
            spells[i].gameObject = Instantiate(magicSpellPrefab, transform.position, Quaternion.identity);
            spells[i].gameObject.SetActive(false);
            spells[i].gameObject.GetComponent<Attack>().SetDamage(weaponData.damage);
            spells[i].animator = spells[i].gameObject.GetComponent<Animator>();
            spells[i].rigidbody = spells[i].gameObject.GetComponent<Rigidbody2D>();
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

        GameObject spell = spells[upgrade].gameObject;
        
        spell.transform.position = transform.position;
        spell.SetActive(true);
        
        Vector2 force = Vector2.right * velocity;
        spells[upgrade].rigidbody.AddForce(force);
        
        spells[upgrade].animator.SetTrigger("Activate");

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
