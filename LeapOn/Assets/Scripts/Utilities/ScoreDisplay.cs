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
        score.text = "Your Score:\n" +PlayerPrefs.GetInt("Score").ToString();
        highScore.text = "High Score:\n" + PlayerPrefs.GetInt("highScore").ToString();
    }   
}
