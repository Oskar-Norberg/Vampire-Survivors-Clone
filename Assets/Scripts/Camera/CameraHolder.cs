using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    [Header("Lerp Settings")]
    [SerializeField] private bool useLerp;
    [SerializeField] private float lerpWeight;

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        
        if (useLerp)
        {
            transform.position = Vector2.Lerp(transform.position, target.position, lerpWeight * Time.deltaTime);
        }
        else
        {
            transform.position = target.position;
        }
    }
}
