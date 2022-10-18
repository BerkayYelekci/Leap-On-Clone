using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenuScoreDisplay : MonoBehaviour
{
    public TMP_Text highScore;



    void Start()
    {
        highScore.text = "High Score:  " + PlayerPrefs.GetInt("highScore").ToString();
    }

   
}
