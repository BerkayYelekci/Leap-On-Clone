using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public AudioSource failAS;
    public AudioClip failAC;
    public static Action gameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Setactive gameovercanvas
            // Destroys player 
            // GAME OVER
            gameOver?.Invoke();
            ////////////
            if (failAS != null)
            {
                failAS.PlayOneShot(failAC);
            }
            collision.gameObject.SetActive(false);
        }
    }
}
