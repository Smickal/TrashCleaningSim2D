using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngineSFX : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip engineClip;
    AudioSource audioSource;

    [SerializeField] float minPitch = 0.1f;
    [SerializeField] float maxPitch = 1.0f;
    [SerializeField] float pitchMultiplier = 1.1f;
    Movement movement;

    float verticalAxis;
    void Start()
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip= engineClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        verticalAxis = movement.GetVerticalaxis();

        float pitch = Mathf.Abs(verticalAxis) * pitchMultiplier;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        audioSource.pitch = pitch;
    }
}
