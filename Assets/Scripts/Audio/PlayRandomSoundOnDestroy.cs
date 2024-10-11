using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaySoundOnDestroy : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    private void OnDestroy()
    {
        int index = Random.Range(0, audioClips.Count);
        
        AudioManager.instance.PlaySoundOneShot(audioClips[index], transform);
    }
}
