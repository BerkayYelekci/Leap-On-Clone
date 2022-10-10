using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainScore : MonoBehaviour
{
    public ScriptableInt score;
    public ScriptableInt scoreMultiplier;
    int incrementScore;
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
    }
    void Multiplier()
    {
        scoreMultiplier.value += 1;
        // Multiply number appears in UI

        ////////////////////////////////
    }
}
