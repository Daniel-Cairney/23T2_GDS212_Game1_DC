using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAudio : MonoBehaviour
{
  
    public Transform playerTransform;
    public float maxDistance = 10f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Calculate the distance between the player and the audio source
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // Adjust audio properties based on the distance
        if (distance <= maxDistance)
        {
            // The player is within range, so enable the audio and adjust the volume
            audioSource.enabled = true;
            audioSource.volume = 1f - (distance / maxDistance);
        }
        else
        {
            // The player is out of range, so disable the audio
            audioSource.enabled = false;
        }
    }
}

