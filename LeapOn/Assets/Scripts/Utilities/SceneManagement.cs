using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SceneManagement : MonoBehaviour
{
    public RectTransform mainMenu;


    private void Start()
    {
        MenuAnimation();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void  MenuAnimation()
    {
        mainMenu.DOLocalMove(Vector2.zero, 1f);
    }

}
