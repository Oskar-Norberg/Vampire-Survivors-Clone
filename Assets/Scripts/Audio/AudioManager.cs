using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject audioPlayerPrefab;
    
    public static AudioManager instance;

    private void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("AudioManager is already instantiated");
            Destroy(gameObject);
        }
    }

    private static void PlaySoundOneShot()
    {
        
    }
}
