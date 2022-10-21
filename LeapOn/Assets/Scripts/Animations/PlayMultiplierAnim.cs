using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMultiplierAnim : MonoBehaviour
{
    public Animator multiplierAnim;
    void Start()
    {
        multiplierAnim.enabled = false;
    }
    private void OnEnable()
    {
        PowerUp.increaseMultiplierAction += PlayAnim;
        ActivatePowerUp.stopMultiplierPU += StopAnim;
    }
    private void OnDisable()
    {
        PowerUp.increaseMultiplierAction -= PlayAnim;
        ActivatePowerUp.stopMultiplierPU -= StopAnim;
    }
    void StopAnim()
    {
        multiplierAnim.enabled = false;
    }
    void PlayAnim()
    {
        multiplierAnim.enabled = true;
    }
}
