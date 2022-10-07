using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ScriptableBool isJumping;

    public float rotateSpeed; 

    public float fallSpeed;

    public GameObject chainSaw;
    Vector2 center;
    Vector2 offset;
    float angle;
    float radius;

    void Start()
    {    
        center = chainSaw.transform.position;
    }
    void Update()
    {
        // If not jumping
        //FallOnGround();
        /////////////////
        if (Input.GetMouseButton(0))
        {
            RotatePlayer();
        }
    }
    // Rotates player clock-wise
    void RotatePlayer()
    {
        // Hem rotate et (LookAt kullan) hem de move et     
        radius = Vector2.Distance(transform.position, chainSaw.transform.position);
        angle += rotateSpeed * Time.deltaTime; // Güncellenecek
        offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
    }
    void FallOnGround()
    {
        float speed = fallSpeed * Time.deltaTime; 
        transform.position = Vector2.MoveTowards(transform.position, center, speed);
    }
}
