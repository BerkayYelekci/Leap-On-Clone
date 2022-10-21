using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource myAS;

    public AudioClip gameMusic;
    public AudioClip colAC;
    public AudioClip failAC;


    private void Start()
    {
        MainGameSound();
    }

    private void CollectibleSound() 
    {
        if (myAS != null)
        {
            myAS.PlayOneShot(colAC);
        }
    }

    private void OnEnable()
    {
        DestroyPlayer.gameOver += DestroyPlayerSound;
        PlayerMovement.collisionSound += CollectibleSound;
        HardModeMovement.collisionSound += CollectibleSound;
    }

    private void OnDisable()
    {
        DestroyPlayer.gameOver -= DestroyPlayerSound;
        PlayerMovement.collisionSound -= CollectibleSound;
        HardModeMovement.collisionSound -= CollectibleSound;
    }

    private void DestroyPlayerSound()
    {
        if (myAS != null)
        {
            if (myAS.clip == gameMusic) 
            {
                myAS.Stop();
            }
            myAS.PlayOneShot(failAC);
        }
    }

    private void MainGameSound()
    {
        myAS = GetComponent<AudioSource>();
        myAS.clip = gameMusic;
        myAS.loop = true;
        myAS.Play();
    }
}
