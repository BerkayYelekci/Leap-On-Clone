using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Color bgColor;

    private void Start()
    {
        bgColor = Random.ColorHSV(.5f, 1f,0.8f,0.8f,0.75f,1);
        GetComponent<MeshRenderer>().material.color = bgColor;
    }

    //Add condition for phase change.

}
