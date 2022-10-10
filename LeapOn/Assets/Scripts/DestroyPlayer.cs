using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroys player 
            // GAME OVER
            Destroy(collision.gameObject);
            // Will add particle effects
        }
    }
}
