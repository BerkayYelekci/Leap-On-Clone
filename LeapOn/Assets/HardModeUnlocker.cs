using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HardModeUnlocker : MonoBehaviour
{
    private int scoreToUnlock = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        scoreToUnlock = PlayerPrefs.GetInt("highScore");
        Debug.Log("Score Unlocked."+scoreToUnlock);
        if (scoreToUnlock >= 100)
        {
            HardModeUnlocked();
        }
    }

    public void HardModeButtonUnlocked()
    {
        SceneManager.LoadScene(2);
    }

    public void HardModeUnlocked()
    {
        LevelSelection.levelHard = true;
    }
}
