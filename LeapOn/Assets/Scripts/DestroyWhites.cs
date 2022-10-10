using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhites : MonoBehaviour
{
    // Destroy itself when collides with the player.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // There will be particle effects when destroy itself here
            //////////////////////////////////////////////////////////
            Destroy(this.gameObject);
        } 
    }
}
