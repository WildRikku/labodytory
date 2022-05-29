using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer singleton;
    private AudioSource audioSource; //Store a reference to our AudioSource.
    
    void Awake()
    {
        if (singleton)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(this);
            // Get a component reference to the attached AudioSource
            audioSource = GetComponent<AudioSource>();
        }
    }
    
    public static void setVolume(float vol)
    {
        singleton.audioSource.volume = vol;
    }
}