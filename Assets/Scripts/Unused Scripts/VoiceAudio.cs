using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceAudio : MonoBehaviour
{
    public AudioClip voiceOver;
    public float volume;
    AudioSource VoiceSource;
    public bool alreadyPlayed = false;

    void Start()
    {
        VoiceSource= GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed)
        {
            VoiceSource.PlayOneShot(voiceOver, volume);
            alreadyPlayed = true;
        }
    }

}