using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource myAS;
    public AudioClip music;

    private void Start()
    {
        // For game screen, may add for MainMenu version.
        myAS = GetComponent<AudioSource>();
        myAS.clip = music;
        myAS.loop = true;
        myAS.Play();
    }


}
