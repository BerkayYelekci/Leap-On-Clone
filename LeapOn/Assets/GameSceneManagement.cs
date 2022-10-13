using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManagement : MonoBehaviour
{
    private void OnEnable()
    {
        DestroyPlayer.gameOver += ReplayGame;
    }

    private void OnDisable()
    {
        DestroyPlayer.gameOver -= ReplayGame;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

}
