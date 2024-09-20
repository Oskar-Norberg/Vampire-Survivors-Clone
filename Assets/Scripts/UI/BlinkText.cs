using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float durationMilliseconds;
    
    private float timer;

    private void OnEnable()
    {
        timer = 0;
    }

    private void OnDisable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= durationMilliseconds / 1000)
        {
            SetVisibility(!text.enabled);
        }
    }

    private void SetVisibility(bool visible)
    {
        text.enabled = visible;
    }
}
