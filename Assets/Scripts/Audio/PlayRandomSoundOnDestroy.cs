using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class PlaySoundOnDestroy : MonoBehaviour
{
    [SerializeField] private AudioManager.AudioType type;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;
        int index = Random.Range(0, audioClips.Count);
        
        AudioManager.instance.PlaySoundOneShot(audioClips[index], type, transform);
    }
}
