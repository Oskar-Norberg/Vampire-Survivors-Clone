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
    
    [SerializeField] private FlipSprite playerFlipSprite;

    private class SpellData
    {
        public GameObject gameObject;
        public Animator animator;
        public Rigidbody2D rigidbody;
    }

    [SerializeField] private int spellCount = 1; 
    
    private SpellData[] spells = new SpellData[4];

    private void Start()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = new SpellData();
            spells[i].gameObject = Instantiate(magicSpellPrefab, transform.position, Quaternion.identity);
            spells[i].gameObject.GetComponent<Attack>().SetDamage(weaponData.damage);
            spells[i].animator = spells[i].gameObject.GetComponent<Animator>();
            spells[i].rigidbody = spells[i].gameObject.GetComponent<Rigidbody2D>();
            spells[i].gameObject.SetActive(false);
        }
        
        playerFlipSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<FlipSprite>();
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
        if (spells == null || playerFlipSprite == null) return;

        for (int i = 0; i < spellCount + 1; i++)
        {
            SpellData spell = spells[i];
        
            spell.gameObject.transform.position = transform.position;
            spell.gameObject.SetActive(true);
        
            Vector2 force = Vector2.right * velocity;

            if (playerFlipSprite.IsFlipped())
            {
                force *= -1.0f;
            }
            
            force = Quaternion.AngleAxis(360.0f / (spellCount + 1) * i, Vector3.forward)  * force;
            
            spell.rigidbody.AddForce(force);
            spell.animator.SetTrigger("Activate");
        }

        timer = 0.0f;
    }
}
