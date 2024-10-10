using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropXPOnDestroy : MonoBehaviour
{
    private XPOrbData xpOrbData;
    [SerializeField] private GameObject xpPrefab;
    
    private static Transform _parent;
    private const string ParentName = "XP Orbs";
    
    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;
        
        if(!xpOrbData) Debug.LogWarning("DropXPOnDestroy: xpOrbData is null");
        if(!xpPrefab) Debug.LogWarning("DropXPOnDestroy: xpPrefab is null");
        if (!_parent) CreateXPParent();
        
        GameObject xpInstance = Instantiate(xpPrefab, _parent);
        xpInstance.transform.SetParent(_parent);
        xpInstance.transform.position = transform.position;

        if (xpInstance.TryGetComponent<XPOrb>(out XPOrb xpOrb)) xpOrb.SetXPOrbData(xpOrbData);
        else Debug.Log("Could not get XPOrb Component");
    }

    public void SetXPOrbData(XPOrbData newXPOrbData)
    {
        xpOrbData = newXPOrbData;
    }
    
    // Puts all XP Orbs in hierarchy under a single parent
    private void CreateXPParent()
    {
        _parent = new GameObject().transform;
        _parent.name = ParentName;
    }
}
