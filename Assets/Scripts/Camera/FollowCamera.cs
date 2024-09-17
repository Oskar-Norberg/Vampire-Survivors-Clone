using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    [Header("Lerp Settings")]
    [SerializeField] private bool useLerp;
    [SerializeField] private float lerpWeight;

    private void Update()
    {
        if (!target) return;
        
        if (useLerp)
        {
            transform.position = Vector2.Lerp(transform.position, target.position, lerpWeight * Time.deltaTime);
        }
        else
        {
            transform.position = (Vector2) target.position;
        }

        // Places camera at a distance for 2d-rendering
        Vector3 position = transform.position;
        position.z = -1;
        transform.position = position;
    }
}
