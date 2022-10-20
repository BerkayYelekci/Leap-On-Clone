using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SceneManagement : MonoBehaviour
{
    public RectTransform mainMenu;

    public GameObject mainMenuObj;
    public GameObject levelPanel;


    private void Start()
    {
        MenuAnimation();
    }

    public void SelectLevel()
    {
        levelPanel.SetActive(true);
        mainMenuObj.SetActive(false);
    }

    public void  MenuAnimation()
    {
        mainMenu.DOLocalMove(Vector2.zero, 1f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    

}
