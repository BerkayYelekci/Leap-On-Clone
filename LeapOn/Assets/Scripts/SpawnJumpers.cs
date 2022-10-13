using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJumpers : MonoBehaviour
{
    float time;
    private void Start()
    {
        time = 1;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SpawnJumper();
            time = 1;
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
