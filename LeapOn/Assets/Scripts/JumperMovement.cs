using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMovement : MonoBehaviour
{
    public ScriptableBool gameOver;
    Vector2 center;
    Vector3 velocity = Vector3.zero;
    float fallTime;
    float distanceToCenter;
    float borderLimit;
    float timeToMove;
    // There is % 20 chance to not movable jumper.
    int moveOrNot;
    void Start()
    {
        moveOrNot = Random.Range(0, 10);
        timeToMove = 1;
        borderLimit = .5f;
        center = GameObject.FindGameObjectWithTag("Center").transform.position;
        DistanceToCenter();
        fallTime = distanceToCenter * 4;
    }
    void Update()
    {
        if (!gameOver.value && moveOrNot < 8)
        {
            DistanceToCenter();
            timeToMove -= Time.deltaTime;
            if (timeToMove <= 0)
            {
                FallOnGround();
            }
        }      
    }
    private void OnEnable()
    {
        moveOrNot = Random.Range(0, 10);
        DistanceToCenter();
        fallTime = distanceToCenter * 4;
        timeToMove = 1f;
        velocity = Vector3.zero;
    }
    void FallOnGround()
    {
        if (distanceToCenter >= borderLimit)
        {
            transform.position = Vector3.SmoothDamp(transform.position, center, ref velocity, fallTime);
            fallTime -= Time.deltaTime;
        }
        else if (distanceToCenter < borderLimit)
        {
            gameObject.SetActive(false);
        }
    }
    void DistanceToCenter()
    {
        distanceToCenter = Vector2.Distance(transform.position, center);
    }
}
