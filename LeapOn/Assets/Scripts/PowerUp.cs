using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    int randomPowerUp;
    float powerUpTime;
    bool jumpPU, rotatePU;
    public GameObject jumpIcon, fastIcon;
    public ScriptableFloat rotateSpeed;
    private void Awake()
    {
        powerUpTime = 1.5f;
        randomPowerUp = Random.Range(0, 2);
        // Jump Higher
        if (randomPowerUp == 0)
        {
            fastIcon.gameObject.SetActive(false);
            rotatePU = false;
            jumpPU = true;
        }
        // RotateFaster
        else if (randomPowerUp == 1)
        {
            jumpIcon.gameObject.SetActive(false);
            jumpPU = false;
            rotatePU = true;
        }
    }
    IEnumerator IncreaseRotateSpeed()
    {
        rotateSpeed.value = 2;
        yield return new WaitForSeconds(powerUpTime);
        gameObject.SetActive(false);
        rotateSpeed.value = 1;
    }
    IEnumerator IncreaseJumpPower()
    {
        yield return new WaitForSeconds(powerUpTime);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && rotatePU)
        {
            StartCoroutine(IncreaseRotateSpeed());
        }
        else if (collision.gameObject.CompareTag("Player") && jumpPU)
        {
            StartCoroutine(IncreaseJumpPower());
        }
    }
}
