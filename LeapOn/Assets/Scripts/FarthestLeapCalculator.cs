using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FarthestLeapCalculator : MonoBehaviour
{
    public ScriptableInt distanceToCenter, farthestLeap;
    public static Action farthestLeapAchieved;
    void Start()
    {
        farthestLeap.value = PlayerPrefs.GetInt("FarthestLeap", 0);
    }
    void Update()
    {
        FarthestLeap();
    }
    void FarthestLeap()
    {
        if (distanceToCenter.value > farthestLeap.value)
        {
            farthestLeap.value = distanceToCenter.value;
            PlayerPrefs.SetInt("FarthestLeap", distanceToCenter.value);
            farthestLeapAchieved?.Invoke();
            // Will add the farthest leap congrats UI
        }
    }
}
