using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GainScore : MonoBehaviour
{
    public ScriptableInt score, highScore;
    public ScriptableInt scoreMultiplier;
    int incrementScore;

    public TMP_Text scoreText;

    private void Awake()
    {
        highScore.value = PlayerPrefs.GetInt("highScore");
    }
    private void Start()
    {
        score.value = 0;
        // It will increment when player passes the multiplier line
        scoreMultiplier.value = 0;
    }
    private void OnEnable()
    {
        PlayerMovement.gainScore += Gain;
        MultiplyScore.multiplyTheScore += Multiplier;
    }
    private void OnDisable()
    {
       PlayerMovement.gainScore -= Gain;
       MultiplyScore.multiplyTheScore -= Multiplier;
    }
    void Gain()
    {
        score.value += scoreMultiplier.value;
        scoreText.text = score.value.ToString();
        PlayerPrefs.SetInt("Score", score.value);
        if (score.value > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score.value);
            highScore.value = score.value;
        }
    }
    void Multiplier()
    {
        scoreMultiplier.value += 1;
        // Multiply number appears in UI

        ////////////////////////////////
    }
}
