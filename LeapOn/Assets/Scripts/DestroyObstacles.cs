using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    [SerializeField] GameObject impactParticles;
    public Collider2D otherCollider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            otherCollider.enabled = false;
            transform.parent.gameObject.SetActive(false);
            ImpactEffect();
        }
    }
    private void ImpactEffect()
    {
        GameObject explosion = Instantiate(impactParticles, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, .1f);
    }
}
