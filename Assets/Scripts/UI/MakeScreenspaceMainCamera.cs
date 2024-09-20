using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeScreenspaceMainCamera : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
    void Start()
    {
        canvas.worldCamera = Camera.main;
    }
}
