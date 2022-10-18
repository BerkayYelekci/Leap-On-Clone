using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public ScriptableBool destroyPlayer;
    public static Action gameOver;
    
    public Collider2D otherCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (destroyPlayer.value)
            {
                otherCollider.enabled = false;
                // GAME OVER
                gameOver?.Invoke();
                // Destroys player 
                collision.gameObject.SetActive(false);
                ////////////
            }
            else if(gameObject.CompareTag("Center") && !destroyPlayer.value)
            {
                gameOver?.Invoke();
                collision.gameObject.SetActive(false);
            }   
            else if (!gameObject.CompareTag("Center") && !destroyPlayer.value)
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    

}
