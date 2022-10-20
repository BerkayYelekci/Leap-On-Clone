using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManagement : MonoBehaviour
{
    public GameObject gameOverUI;

    private void OnEnable()
    {
        DestroyPlayer.gameOver += GameOverUI;
    }

    private void OnDisable()
    {
        DestroyPlayer.gameOver -= GameOverUI;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
