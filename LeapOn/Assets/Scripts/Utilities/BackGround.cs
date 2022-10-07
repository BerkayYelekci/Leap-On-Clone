using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Color bgColor;

    private void Start()
    {
        bgColor = Random.ColorHSV(.5f, 1,0.5f,0.5f);
        GetComponent<MeshRenderer>().material.color = bgColor;
    }

}
