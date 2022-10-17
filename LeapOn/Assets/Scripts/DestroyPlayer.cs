using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public static Action gameOver;
    
    public Collider2D otherCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            otherCollider.enabled = false;
            // Setactive gameovercanvas
            // Destroys player 
            // GAME OVER
            gameOver?.Invoke();
            ////////////
           
            collision.gameObject.SetActive(false);
        }
    }

    

}
