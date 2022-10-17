using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    int randomPowerUp;
    bool jumpPU, fastPU;
    public GameObject jumpIcon, fastIcon;
    private void Awake()
    {
        randomPowerUp = Random.Range(0, 2);
        // Jump Higher
        if (randomPowerUp == 0)
        {
            fastIcon.gameObject.SetActive(false);
            fastPU = false;
            jumpPU = true;
        }
        // RotateFaster
        else if (randomPowerUp == 1)
        {
            jumpIcon.gameObject.SetActive(false);
            jumpPU = false;
            fastPU = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
