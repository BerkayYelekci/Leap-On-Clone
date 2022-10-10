using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public AudioSource failAS;
    public AudioClip failAC;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroys player 
            // GAME OVER
            if (failAS != null)
            {
                failAS.PlayOneShot(failAC);
            }

            Destroy(collision.gameObject);
            // Will add particle effects
        }
    }
}
