using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    int randomPowerUp;
    bool jumpPU, rotatePU, destroyBlackPU;
    public GameObject jumpIcon, fastIcon, destroyBlackIcon;
    public static Action rotatePowerUpAction, jumpPowerUpAction, destroyBlackAction;
    private void Awake()
    {
        randomPowerUp = UnityEngine.Random.Range(0, 3);
        // Jump Higher Object Active
        if (randomPowerUp == 0)
        {
            fastIcon.gameObject.SetActive(false);
            destroyBlackIcon.gameObject.SetActive(false);
            rotatePU = false;
            jumpPU = true;
            destroyBlackPU = false;
        }
        // Rotate Faster Object Active
        else if (randomPowerUp == 1)
        {
            jumpIcon.gameObject.SetActive(false);
            destroyBlackIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = true;
            destroyBlackPU = false;
        }
        // Destroy Black Gameobjects
        else if (randomPowerUp == 2)
        {
            jumpIcon.gameObject.SetActive(false);
            fastIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = false;
            destroyBlackPU = true;
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
        else if (collision.gameObject.CompareTag("Player") && destroyBlackPU)
        {
            destroyBlackAction?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
