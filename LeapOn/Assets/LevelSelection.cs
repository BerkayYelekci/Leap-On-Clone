using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    public Button normalModeButton, hardModeButton;

    public static bool levelNormal,levelHard = false;

    private void Start()
    {
        levelNormal = true;

        if (levelHard == true)
        {
            hardModeButton.interactable = true;
            Debug.Log("Hard mode unlocked.");
        }
    }
  

}
