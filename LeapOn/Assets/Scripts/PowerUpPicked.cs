using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPicked : MonoBehaviour
{
    public GameObject protectImage;
    private void Start()
    {
        protectImage.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        PowerUp.destroyBlackAction += PlayAnim;
        ActivatePowerUp.stopDestroyBlackPU += StopAnim;
    }
    private void OnDisable()
    {
        PowerUp.destroyBlackAction -= PlayAnim;
        ActivatePowerUp.stopDestroyBlackPU -= StopAnim;
    }
    void PlayAnim()
    {
        protectImage.gameObject.SetActive(true);
    }
    void StopAnim()
    {
        protectImage.gameObject.SetActive(false);
    }
}
