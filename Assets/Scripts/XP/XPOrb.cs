using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    private XPOrbData xpOrbData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetXPOrbData(XPOrbData newXpOrbData)
    {
        xpOrbData = newXpOrbData;
        spriteRenderer.sprite = xpOrbData.texture;
    }
    
    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;
        if (!xpOrbData)
        {
            Debug.Log("XP Orb Data Not Found");
            return;
        }
        ExperienceManager.instance.AddExperience(xpOrbData.value);
    }
}
