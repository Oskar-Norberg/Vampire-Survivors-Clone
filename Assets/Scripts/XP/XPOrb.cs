using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;
        throw new NotImplementedException("XP Orb not implemented");
    }
}
