using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    [SerializeField] private int xpValue = 1;
    
    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return; 
        ExperienceManager.instance.AddExperience(xpValue);
    }
}
