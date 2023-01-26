using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.playOnAwake = s.playOnAwake;
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.spatialBlend = s.audio3D;
            s.audioSource.loop = s.isLooping;
        }
    }

    private void Start()
    {
        
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s != null)
        {
            s.audioSource.Play();
            Debug.Log("Played");
        }
    }

    public void WaitToPlay(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (!s.audioSource.isPlaying)
        {
            s.audioSource.Play();
        }
    }

    public void StopPlayingAllSound()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource.Stop();
        }
    }

    public void ChangeVolume(string name, float tempVolume)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        s.volume = tempVolume;
        s.audioSource.volume = s.volume;
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if(s != null)
            s.audioSource.Stop();
    }
}
