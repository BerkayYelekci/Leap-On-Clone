using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpE : MonoBehaviour
{
    [SerializeField] GameObject powerUpParticles;


    private void OnEnable()
    {
        PowerUp.rotatePowerUpAction += PoUPEffects;
        PowerUp.jumpPowerUpAction += PoUPEffects;
        PowerUp.destroyBlackAction += PoUPEffects;
        PowerUp.increaseMultiplierAction += PoUPEffects;
        PowerUp.destroyInstantAction += PoUPEffects;
    }


    private void OnDisable()
    {
        PowerUp.rotatePowerUpAction -= PoUPEffects;
        PowerUp.jumpPowerUpAction -= PoUPEffects;
        PowerUp.destroyBlackAction -= PoUPEffects;
        PowerUp.increaseMultiplierAction -= PoUPEffects;
        PowerUp.destroyInstantAction -= PoUPEffects;
    }

    public void PoUPEffects()
    {
        ImpactEffect();
    }

    private void ImpactEffect()
    {
        GameObject explosion = Instantiate(powerUpParticles, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, .15f);
    }
}
