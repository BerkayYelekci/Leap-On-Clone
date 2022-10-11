using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeIntensity;

    public void ShakingSequence()
    {
        Camera.main.DOShakePosition(shakeDuration, shakeIntensity,fadeOut:true);
    }
        
}
