using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(objectToDestroy);
    }
}
