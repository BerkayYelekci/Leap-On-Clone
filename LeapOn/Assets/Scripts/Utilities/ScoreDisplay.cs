using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text highScore;
    public TMP_Text score;

    void Start()
    {
        score.text =  PlayerPrefs.GetInt("Score").ToString();
        highScore.text = "High Score:  " + PlayerPrefs.GetInt("highScore").ToString();
    }

        
}
