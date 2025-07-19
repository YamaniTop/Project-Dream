using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sound;
    public float voulme;
    private AudioSource audioSrc => GetComponent<AudioSource>(); 
    public void PlaySound(AudioClip clip, bool destroyed = false)
    {
        audioSrc.PlayOneShot(clip, voulme);
    }

}
