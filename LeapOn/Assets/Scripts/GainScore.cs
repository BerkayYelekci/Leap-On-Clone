using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainScore : MonoBehaviour
{
    public ScriptableInt score;
    int incrementScore;
    private void Start()
    {
        score.value = 0;
        // It will rise incremental when player exceeds the multiplier line
        incrementScore = 1;
    }
    private void OnEnable()
    {
      //  PlayerMovement.gainScore += Gain;
    }
    private void OnDisable()
    {
     //  PlayerMovement.gainScore -= Gain;
    }
    void Gain()
    {
        score.value += incrementScore;
    }
}
