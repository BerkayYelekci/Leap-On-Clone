using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text highScore;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
