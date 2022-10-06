using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ScriptableBool isJumping;

    public float rotateSpeed = 5f;
    float radius;

    public float fallSpeed;

    public GameObject chainSaw;
    Vector2 centre;
    float angle;
    void Start()
    {    
        centre = chainSaw.transform.position;
        radius = Vector2.Distance(transform.position, chainSaw.transform.position);
    }
    void Update()
    {
        RotatePlayer();
        FallOnTheGround();
    }
    // Pulls the ball to the center of the scene
    void FallOnTheGround()
    {
        if (!isJumping.value)
        {
            float speed = fallSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, centre, speed);
        }
    }
    // Rotates player clock-wise
    void RotatePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            radius = Vector2.Distance(transform.position, chainSaw.transform.position);
            angle += rotateSpeed * Time.deltaTime;
            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
            transform.position = centre + offset;
        }
    }
}
