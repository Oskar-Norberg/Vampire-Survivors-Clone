using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioPlayerPrefab;
    
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

    private void PlaySoundOneShot(AudioClip audioClip, Transform spawnTransform)
    {
        AudioSource audioSource = Instantiate(audioPlayerPrefab, spawnTransform.position, spawnTransform.rotation);
        
        audioSource.clip = audioClip;
        
        audioSource.Play();
        
        float audioLength = audioSource.clip.length;
        
        Destroy(audioSource.gameObject, audioLength);
    }
}
