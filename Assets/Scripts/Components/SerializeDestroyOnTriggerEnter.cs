using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializeDestroyOnTriggerEnter : MonoBehaviour
{
    [SerializeField] GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(objectToDestroy);
    }
}
