using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameCanvasUI : MonoBehaviour
{
    private TMP_Text scoreText;

    public GameObject score;


    void Start()
    {
        scoreText = score.GetComponent<TextMeshProUGUI>();
        DisplayScore();
    }

    private void OnEnable()
    {
        DestroyPlayer.gameOver += DeactivateScore;
    }

    private void OnDisable()
    {
        DestroyPlayer.gameOver -= DeactivateScore;
    }

    private void DisplayScore()
    {
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    private void DeactivateScore()
    {
        score.SetActive(false);
    }

}
