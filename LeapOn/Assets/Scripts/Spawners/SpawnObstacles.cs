using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public ScriptableBool gameOver;
    public ScriptableInt score;
    float spawnTime, spawnTimeValue;
    float spawnPosX, spawnPosY, posBorderX, posBorderY;
    int spawnArea;
    public Transform center;
    private void OnEnable()
    {
        GainScore.onGainScore += ChangeSpawnTime;
    }
    private void OnDisable()
    {
        GainScore.onGainScore -= ChangeSpawnTime;

    }
    void ChangeSpawnTime()
    {
        if (score.value >= 75)
        {
            spawnTimeValue = 1.75f;
        }
        else if (score.value >= 175)
        {
            spawnTimeValue = 1.5f;
        }
    }
    void Start()
    {
        posBorderX = 1.5f;
        posBorderY = 7f;
        spawnArea = Random.Range(0,4);
        spawnTimeValue = 2f;
        spawnTime = spawnTimeValue;
    }
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 && !gameOver.value)
        {
            SpawnObstacle();
        }
    }
    // Spawn obstacle with respect to area 
    void SpawnObstacle()
    {
        // Area I. of the coordinate system
        if (spawnArea == 0)
        {
            // To make them to spawn another area
            spawnArea = 1;
            //////////////
            RandomSpawnPos();
            SpawnFunc();
            //////////////
            spawnTime = spawnTimeValue;
        }
        // Area II. of the coordinate system
        else if (spawnArea == 1)
        {
            // To make them to spawn another area
            spawnArea = 2;
            //////////////
            RandomSpawnPos();
            SpawnFunc();
            //////////////
            spawnTime = spawnTimeValue;
        }
        // Area III. of the coordinate system
        else if (spawnArea == 2)
        {
            // To make them to spawn another area
            spawnArea = 3;
            //////////////
            RandomSpawnPos();
            SpawnFunc();
            //////////////
            spawnTime = spawnTimeValue;
        }
        // Area IV. of the coordinate system
        else if (spawnArea == 3)
        {
            // To make them to spawn another area
            spawnArea = 0;
            //////////////
            RandomSpawnPos(); 
            SpawnFunc();
            //////////////
            spawnTime = spawnTimeValue;
        }
    }
    // Randomly spawn obstacle (Position-Wise)
    void RandomSpawnPos()
    {
        // Area I
        if (spawnArea == 0)
        {
            spawnPosX = Random.Range(posBorderX, posBorderY);
            spawnPosY = Random.Range(posBorderX, posBorderY);
        }
        // Area II
        else if (spawnArea == 1)
        {
            spawnPosX = Random.Range(-posBorderX, -posBorderY);
            spawnPosY = Random.Range(posBorderX, posBorderY);
        }
        // Area III
        else if (spawnArea == 2)
        {
            spawnPosX = Random.Range(-posBorderX, -posBorderY);
            spawnPosY = Random.Range(-posBorderX, -posBorderY);
        }
        // Area IV
        else if (spawnArea == 3)
        {
            spawnPosX = Random.Range(posBorderX, posBorderY);
            spawnPosY = Random.Range(-posBorderX, -posBorderY);
        }
    }
    // Simply spawn an obstacle
    void SpawnFunc()
    {
        GameObject obstacle = ObstaclePool.SharedInstance.GetPooledObjects();
        if (obstacle != null)
        {
            obstacle.transform.position = new Vector2(spawnPosX, spawnPosY);
            obstacle.transform.rotation = ArrangeRotation(obstacle);
            obstacle.SetActive(true);
        }
    }
    // For arrange the rotation of the newly spawned obstacle. White side of the obstacle is always faced to center
    Quaternion ArrangeRotation(GameObject go)
    {
        Vector2 direction = ((Vector2)center.position - (Vector2)go.transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var offset = 90f;
        go.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        return go.transform.rotation;
    }
}
