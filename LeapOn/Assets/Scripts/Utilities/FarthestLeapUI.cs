using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FarthestLeapUI : MonoBehaviour
{
    public GameObject farthestLeapText;
    float timeToStay;
    private void Start()
    {
        timeToStay = 1;
    }
    private void OnEnable()
    {
        FarthestLeapCalculator.farthestLeapAchieved += ActivateTheText;
    }
    private void OnDisable()
    {
        FarthestLeapCalculator.farthestLeapAchieved -= ActivateTheText;
    }
    void ActivateTheText()
    {
        StartCoroutine(ActivateNumerator());
    }

    IEnumerator ActivateNumerator()
    {
        farthestLeapText.SetActive(true);
        yield return new WaitForSeconds(timeToStay);
        farthestLeapText.SetActive(false);
    }
}
