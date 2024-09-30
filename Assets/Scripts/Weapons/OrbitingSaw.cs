using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrbitingSaw : WeaponBase
{
    [SerializeField] private Attack attack;
    [SerializeField] private GameObject orbitingPrefab;
    [SerializeField] private Transform orbitCenter;
    [SerializeField] private float orbitRadius;
    [SerializeField] private float orbitSpeed;
    [SerializeField] private int startingNrOfSaws;

    private List<GameObject> orbitingObjects = new List<GameObject>();
    
    private void Start()
    {
        for (int i = 0; i < startingNrOfSaws; i++)
        {
            AddSaw();
        }
        SetAttackDamage();
    }

    private void SetAttackDamage()
    {
        attack.SetDamage(weaponData.damage);
    }

    public void AddSaw()
    {
        GameObject newBomb = Instantiate(orbitingPrefab, orbitCenter);
        
        orbitingObjects.Add(newBomb);

        for (int i = 0; i < orbitingObjects.Count; i++)
        {
            float rad = 2 * Mathf.PI / orbitingObjects.Count * i;
            Vector2 pos = new Vector2();
            pos.x = Mathf.Cos(rad);
            pos.y = Mathf.Sin(rad);
            pos *= orbitRadius;
            orbitingObjects[i].transform.localPosition = (Vector3) pos;
        }
    }

    private void RotateOrbitingObjects()
    {
        if (!orbitCenter || orbitingObjects == null) return;
        if (orbitingObjects.Count <= 0) return;
        

        orbitCenter.Rotate(Vector3.forward, orbitSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (IsPaused) return; 
        RotateOrbitingObjects();
    }

    protected override void Pause()
    {
        base.Pause();
        IsPaused = true;
    }

    protected override void UnPause()
    {
        base.UnPause();
        IsPaused = false;
    }
}
