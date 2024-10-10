using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropXPOnDestroy : MonoBehaviour
{
    private XPOrbData xpOrbData;
    [SerializeField] private GameObject xpPrefab;

    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;
        
        if(!xpOrbData) Debug.LogWarning("DropXPOnDestroy: xpOrbData is null");
        if(!xpPrefab) Debug.LogWarning("DropXPOnDestroy: xpPrefab is null");
        
        GameObject xpInstance = Instantiate(xpPrefab, transform.position, transform.rotation);

        if (xpInstance.TryGetComponent<XPOrb>(out XPOrb xpOrb)) xpOrb.SetXPOrbData(xpOrbData);
        else Debug.Log("Could not get XPOrb Component");
    }

    public void SetXPOrbData(XPOrbData newXPOrbData)
    {
        xpOrbData = newXPOrbData;
    }
}
