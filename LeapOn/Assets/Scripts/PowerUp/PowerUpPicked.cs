using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPicked : MonoBehaviour
{
    public GameObject protectImage;
    public GameObject speedUpTrail;
    TrailRenderer normalTrail;
    private void Start()
    {
        speedUpTrail.gameObject.SetActive(false);
        protectImage.gameObject.SetActive(false);
        normalTrail = GetComponent<TrailRenderer>();
    }
    private void OnEnable()
    {
        PowerUp.destroyBlackAction += PlayProtectAnim;
        ActivatePowerUp.stopDestroyBlackPU += StopProtectAnim;
        PowerUp.rotatePowerUpAction += PlaySpeedAnim;
        ActivatePowerUp.stopSpeedUpPU += StopSpeedAnim;
    }
    private void OnDisable()
    {
        PowerUp.destroyBlackAction -= PlayProtectAnim;
        ActivatePowerUp.stopDestroyBlackPU -= StopProtectAnim;
        PowerUp.rotatePowerUpAction -= PlaySpeedAnim;
        ActivatePowerUp.stopSpeedUpPU -= StopSpeedAnim;
    }
    void PlaySpeedAnim()
    {
        normalTrail.enabled = false;
        speedUpTrail.gameObject.SetActive(true);
    }
    void StopSpeedAnim()
    {
        normalTrail.enabled = true;
        speedUpTrail.gameObject.SetActive(false);
    }
    void PlayProtectAnim()
    {
        protectImage.gameObject.SetActive(true);
    }
    void StopProtectAnim()
    {
        protectImage.gameObject.SetActive(false);
    }
}
