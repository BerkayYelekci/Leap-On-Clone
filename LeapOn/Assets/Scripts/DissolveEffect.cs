using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    Material mat;

    bool isDissolving = false;

    float fade = 1f;

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDissolving = true;
        }

        if (isDissolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            mat.SetFloat("_Fade", fade);
        }
    }
}
