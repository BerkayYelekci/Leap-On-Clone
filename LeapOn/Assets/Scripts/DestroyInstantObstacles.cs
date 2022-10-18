using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInstantObstacles : MonoBehaviour
{
    int activeObjects, willDestroyCount;
    public List<Transform> activeObjectList;
    private void OnEnable()
    {
        PowerUp.destroyInstantAction += DestroyInstantly;
    }
    private void OnDisable()
    {
        PowerUp.destroyInstantAction -= DestroyInstantly;
    }
    void CalculateListCount()
    {
        activeObjects = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                activeObjects++;
                activeObjectList.Add(child);
            }
        }
    }
    void DestroyInstantly()
    {     
        CalculateListCount();
        if (activeObjectList.Count != 0)
        {
            willDestroyCount = Random.Range(1, activeObjects);
            for (int i = 0; i < willDestroyCount; i++)
            {
                activeObjectList[i].gameObject.SetActive(false);
            }
            activeObjectList.Clear();
        }    
    }
}
