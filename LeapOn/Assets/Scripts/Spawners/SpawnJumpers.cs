using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJumpers : MonoBehaviour
{
    public ScriptableBool gameOver;
    public ScriptableInt score;
    float time, timeValue;
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
            timeValue = .75f;
        }
        else if (score.value >= 175)
        {
            timeValue = .7f;
        }
    }
    private void Start()
    {
        timeValue = 1;
        time = timeValue;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 && !gameOver.value)
        {
            SpawnJumper();
            time = timeValue;
        }
    }
    void SpawnJumper()
    {
        GameObject whiteGO = ObjectPool.SharedInstance.GetPooledObjects();
        if (whiteGO != null)
        {
            whiteGO.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            whiteGO.transform.rotation = Quaternion.identity;
            whiteGO.SetActive(true);
        }
    }
}
