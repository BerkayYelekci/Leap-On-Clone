using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    int randomPowerUp;
    bool jumpPU, rotatePU;
    public GameObject jumpIcon, fastIcon;
    public static Action rotatePowerUpAction, jumpPowerUpAction;
    private void Awake()
    {
        randomPowerUp = UnityEngine.Random.Range(0, 2);
        // Jump Higher Object Active
        if (randomPowerUp == 0)
        {
            fastIcon.gameObject.SetActive(false);
            rotatePU = false;
            jumpPU = true;
        }
        // Rotate Faster Object Active
        else if (randomPowerUp == 1)
        {
            jumpIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && rotatePU)
        {
            rotatePowerUpAction?.Invoke();
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Player") && jumpPU)
        {
            jumpPowerUpAction?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
