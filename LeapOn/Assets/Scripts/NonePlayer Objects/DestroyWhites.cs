using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhites : MonoBehaviour
{
    [SerializeField] GameObject impactParticles;

    // Destroy itself when collides with the player.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // There will be particle effects when destroy itself here
            //////////////////////////////////////////////////////////
            this.gameObject.SetActive(false);

            ImpactEffect();
        } 
    }

    private void ImpactEffect()
    {
        GameObject explosion = Instantiate(impactParticles, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion,.1f);
    }
}
