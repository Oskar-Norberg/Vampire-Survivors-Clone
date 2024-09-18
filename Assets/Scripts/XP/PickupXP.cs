using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupXP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent<XPOrb>(out XPOrb orb))
        {
            orb.Pickup();
        }
    }
}
