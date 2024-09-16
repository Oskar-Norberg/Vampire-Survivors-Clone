using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
