using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScriptableBool isJumping;
    public ScriptableBool gameOver;
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
        isJumping.value = false;
        gameOver.value = false;
    }
    void GameOver()
    {
        gameOver.value = true;
    }
}
