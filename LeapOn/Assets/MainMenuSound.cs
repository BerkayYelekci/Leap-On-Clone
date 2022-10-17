using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    AudioSource mainAS;

    public AudioClip mainMenuMusic;

    void Start()
    {
        mainAS = GetComponent<AudioSource>();
        mainAS.clip = mainMenuMusic;
        mainAS.loop = true;
        mainAS.Play();
    }

   
}
