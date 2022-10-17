using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScriptableBool isJumping, destroyPlayer;
    public ScriptableBool gameOver;
    public ScriptableFloat rotateSpeed, jumpSpeed;
    private void OnEnable()
    {
        DestroyPlayer.gameOver += GameOver;
    }
    private void OnDisable()
    {
        DestroyPlayer.gameOver -= GameOver;
    }
    void Awake()
    {
        destroyPlayer.value = true;
        isJumping.value = false;
        gameOver.value = false;
        rotateSpeed.value = 1;
        jumpSpeed.value = 3;
    }
    void GameOver()
    {
        gameOver.value = true;
        PlayerPrefs.Save();
    }
}
