using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public ScriptableBool gameOver;
    float time;
    int minTime, maxTime;
    private void Start()
    {
        minTime = 5;
        maxTime = 10;
        time = Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 && !gameOver.value)
        {
            SpawnPowerUp();
            time = Random.Range(minTime, maxTime);
        }
    }
    void SpawnPowerUp()
    {
        GameObject powerUp = PowerUpPool.SharedInstance.GetPooledObjects();
        if (powerUp != null)
        {
            powerUp.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            powerUp.transform.rotation = Quaternion.identity;
            powerUp.SetActive(true);
        }
    }
}
