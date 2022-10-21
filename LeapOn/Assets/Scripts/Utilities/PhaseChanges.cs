using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChanges : MonoBehaviour
{
    public GameObject phase1, phase2, phase3;
    public ScriptableInt score;
    int toPhase2, toPhase3;
    private void OnEnable()
    {
        GainScore.onGainScore += ChangePhase;
    }
    private void OnDisable()
    {
        GainScore.onGainScore -= ChangePhase;
    }
    void Start()
    {
        toPhase2 = 75;
        toPhase3 = 175;
    }
    void ChangePhase()
    {
        if (score.value >= toPhase2 && score.value < toPhase3)
        {
            phase1.gameObject.SetActive(false);
            phase2.gameObject.SetActive(true);
        }
        else if (score.value >= toPhase3)
        {
            phase2.gameObject.SetActive(false);
            phase3.gameObject.SetActive(true);
        }
    }
}
