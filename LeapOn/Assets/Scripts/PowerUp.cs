using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    int randomPowerUp;
    bool jumpPU, rotatePU, destroyBlackPU, increaseMultiplierPU, destroyInstantPU;
    public GameObject jumpIcon, fastIcon, destroyBlackIcon, increaseMultiplierIcon, destroyInstantIcon;
    public static Action rotatePowerUpAction, jumpPowerUpAction, destroyBlackAction, increaseMultiplierAction, destroyInstantAction;
    private void Awake()
    {
        randomPowerUp = UnityEngine.Random.Range(0, 5);
        // Jump Higher Object Active
        if (randomPowerUp == 0)
        {
            fastIcon.gameObject.SetActive(false);
            destroyBlackIcon.gameObject.SetActive(false);
            increaseMultiplierIcon.gameObject.SetActive(false);
            destroyInstantIcon.gameObject.SetActive(false);
            rotatePU = false;
            jumpPU = true;
            destroyBlackPU = false;
            destroyInstantPU = false;
        }
        // Rotate Faster Object Active
        else if (randomPowerUp == 1)
        {
            jumpIcon.gameObject.SetActive(false);
            destroyBlackIcon.gameObject.SetActive(false);
            increaseMultiplierIcon.gameObject.SetActive(false);
            destroyInstantIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = true;
            destroyBlackPU = false;
            destroyInstantPU = false;
        }
        // Destroy Black Gameobjects
        else if (randomPowerUp == 2)
        {
            jumpIcon.gameObject.SetActive(false);
            fastIcon.gameObject.SetActive(false);
            increaseMultiplierIcon.gameObject.SetActive(false);
            destroyInstantIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = false;
            destroyBlackPU = true;
            destroyInstantPU = false;
        }
        // Increase Multiplier Rate By 2x 
        else if (randomPowerUp == 3)
        {
            jumpIcon.gameObject.SetActive(false);
            fastIcon.gameObject.SetActive(false);
            destroyBlackIcon.gameObject.SetActive(false);
            destroyInstantIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = false;
            destroyBlackPU = false;
            increaseMultiplierPU = true;
            destroyInstantPU = false;
        }
        // Destroy Some of Black Objects Instant
        else if (randomPowerUp == 4)
        {
            jumpIcon.gameObject.SetActive(false);
            fastIcon.gameObject.SetActive(false);
            destroyBlackIcon.gameObject.SetActive(false);
            increaseMultiplierIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = false;
            destroyBlackPU = false;
            increaseMultiplierPU = false;
            destroyInstantPU = true;
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
        else if (collision.gameObject.CompareTag("Player") && increaseMultiplierPU)
        {
            increaseMultiplierAction?.Invoke();
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Player") && destroyInstantPU)
        {
            destroyInstantAction?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
