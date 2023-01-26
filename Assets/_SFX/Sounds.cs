using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    public bool playOnAwake = false;
    public bool isLooping = false;
    public float audio3D = 1f;

    [HideInInspector] public AudioSource audioSource;
}
