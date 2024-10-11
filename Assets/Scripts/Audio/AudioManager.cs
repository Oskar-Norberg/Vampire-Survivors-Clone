using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public enum AudioType {Standard, Music, Reverb}
    [SerializeField] private AudioSource audioPlayerPrefab;
    [SerializeField] private AudioMixer audioMixer;
    
    private Dictionary<string, AudioMixerGroup> audioMixers = new Dictionary<string, AudioMixerGroup>();
    
    public static AudioManager instance;

    private void Start()
    {
        if (!instance)
        {
            instance = this;
            FindAudioMixerGroups();
        }
        else
        {
            Debug.LogWarning("AudioManager is already instantiated");
            Destroy(gameObject);
        }
    }

    public void PlaySoundOneShot(AudioClip audioClip, Transform spawnTransform)
    private void FindAudioMixerGroups()
    {
        AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups(string.Empty);

        foreach (AudioMixerGroup audioMixerGroup in audioMixerGroups)
        {
            Debug.Log(audioMixerGroup.name);
            audioMixers[audioMixerGroup.name] = audioMixerGroup;
        }
    }

    public void PlaySoundOneShot(AudioClip audioClip, AudioType type, Transform spawnTransform)
    {
        AudioSource audioSource = Instantiate(audioPlayerPrefab, spawnTransform.position, spawnTransform.rotation);
        
        audioSource.clip = audioClip;
        
        audioSource.Play();
        
        float audioLength = audioSource.clip.length;
        
        Destroy(audioSource.gameObject, audioLength);
    }
}
