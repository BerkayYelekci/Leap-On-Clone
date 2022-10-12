using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeIntensity;
    CameraShake camShake;

    public ParticleSystem impactParticles;

    private void Start()
    {
        camShake = GetComponent<CameraShake>();
    }
    private void OnEnable()
    {
        PlayerMovement.onTouchWhite += EffectSequence;
    }
    private void OnDisable()
    {
        PlayerMovement.onTouchWhite -= EffectSequence;
    }

    private void EffectSequence()
    {
        camShake.ShakingSequence(); // may change where to call this function.
        ParticleOnImpact();
    }

    public void ShakingSequence()
    {
        Camera.main.DOShakePosition(shakeDuration, shakeIntensity, fadeOut: true);
    }

    private void ParticleOnImpact()
    {
        impactParticles.Play();
    }
}
