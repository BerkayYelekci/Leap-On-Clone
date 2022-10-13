using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplierText : MonoBehaviour
{
    public TextMeshProUGUI multiplierText;
    public ScriptableInt multiplierScore;
    int multiplier;
    void Start()
    {
        multiplier = multiplierScore.value + 1;
        multiplierText.text = "x" + multiplier.ToString();
    }
    private void OnEnable()
    {
        MultiplyScore.multiplyTheScore += MultiplyScoreTextUpdate;
    }
    private void OnDisable()
    {
        MultiplyScore.multiplyTheScore -= MultiplyScoreTextUpdate;
    }
    void MultiplyScoreTextUpdate()
    {
        multiplier = multiplierScore.value + 1;
        multiplierText.text = "x" + multiplier.ToString();
    }
}
