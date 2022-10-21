using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GainScore : MonoBehaviour
{
    public ScriptableInt score, highScore;
    public ScriptableInt scoreMultiplier;
    public ScriptableBool increaseMultiplier;

    public static Action onGainScore;

    public Animator highScoreAnimator;
    public TMP_Text scoreText;
    private void Awake()
    {
        highScoreAnimator.enabled = false;
        highScore.value = PlayerPrefs.GetInt("highScore");
    }
    private void Start()
    {
        score.value = 0;
        PlayerPrefs.SetInt("Score", score.value);
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
        if (!increaseMultiplier.value)
        {
            score.value += scoreMultiplier.value;
        }
        else if (increaseMultiplier)
        {
            score.value += (scoreMultiplier.value * 2);
        }
        scoreText.text = score.value.ToString();
        PlayerPrefs.SetInt("Score", score.value);
        if (score.value > PlayerPrefs.GetInt("highScore"))
        {
            highScoreAnimator.enabled = true;
            PlayerPrefs.SetInt("highScore", score.value);
            highScore.value = score.value;
        }
        onGainScore?.Invoke();
    }
    void Multiplier()
    {
        scoreMultiplier.value += 1;
    }
}
