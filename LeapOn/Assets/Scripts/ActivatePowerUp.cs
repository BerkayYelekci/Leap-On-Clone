using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerUp : MonoBehaviour
{
    public static Action stopMultiplierPU, stopDestroyBlackPU;
    public ScriptableFloat rotateSpeed, jumpSpeed;
    public ScriptableBool jumpPU, rotatePU, destroyBlackPU, increaseMultiplierPU;
    float powerUpTime, increaseMultiplierPowerUpTime;
    private void Awake()
    {
        powerUpTime = 5f;
        increaseMultiplierPowerUpTime = 7f;
        jumpPU.value = false;
        rotatePU.value = false;
        increaseMultiplierPU.value = false;
    }
    private void OnEnable()
    {
        PowerUp.rotatePowerUpAction += IncreaseRotateSpeed;
        PowerUp.jumpPowerUpAction += IncreaseJumpPower;
        PowerUp.destroyBlackAction += DestroyBlackObjects;
        PowerUp.increaseMultiplierAction += IncreaseMultiplier;
    }
    private void OnDisable()
    {
        PowerUp.rotatePowerUpAction -= IncreaseRotateSpeed;
        PowerUp.jumpPowerUpAction -= IncreaseJumpPower;
        PowerUp.destroyBlackAction -= DestroyBlackObjects;
        PowerUp.increaseMultiplierAction -= IncreaseMultiplier;
    }
    private void Update()
    {
        RotatePU();
        JumpPU();
        DestroyBlackPU();
        IncreaseMultiplierPU();
    }
    void RotatePU()
    {
        if (rotatePU.value)
        {
            powerUpTime -= Time.deltaTime;
            if (powerUpTime <= 0)
            {
                rotateSpeed.value = 1;
                rotatePU.value = false;
                powerUpTime = 5f;
            }
        }
    }
    void JumpPU()
    {
        if (jumpPU.value)
        {
            powerUpTime -= Time.deltaTime;
            if (powerUpTime <= 0)
            {
                jumpPU.value = false;
                jumpSpeed.value = 5;
                powerUpTime = 5f;
            }
        }
    }
    void DestroyBlackPU()
    {
        if (!destroyBlackPU.value)
        {
            powerUpTime -= Time.deltaTime;
            if (powerUpTime <= 0)
            {
                stopDestroyBlackPU?.Invoke();
                destroyBlackPU.value = true;
                powerUpTime = 5f;
            }
        }
    }
    void IncreaseMultiplierPU()
    {
        if (increaseMultiplierPU.value)
        {
            increaseMultiplierPowerUpTime -= Time.deltaTime;
            if (increaseMultiplierPowerUpTime <= 0)
            {
                stopMultiplierPU?.Invoke();
                increaseMultiplierPU.value = false;
                increaseMultiplierPowerUpTime = 7f;
            }
        }
    }
    void IncreaseRotateSpeed()
    {
        rotatePU.value = true;
        rotateSpeed.value = 2;
        powerUpTime = 5f;
    }
    void IncreaseJumpPower()
    {
        jumpPU.value = true;
        jumpSpeed.value = 5f;
        powerUpTime = 5f;
    }
    void DestroyBlackObjects()
    {
        destroyBlackPU.value = false;
        powerUpTime = 5f;
    }
    void IncreaseMultiplier()
    {
        increaseMultiplierPU.value = true;
        increaseMultiplierPowerUpTime = 7f;
    }
}
