using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldownTime;
    

    
    // Start is called before the first frame update
    void Start()
    {
    }

