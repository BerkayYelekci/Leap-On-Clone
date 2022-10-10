using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Action gainScore; 

    public ScriptableBool isJumping;

    public AudioSource colAS;
    public AudioClip colAC;

    public float rotateSpeed; 
    public float fallSpeed;
    public float jumpSpeed;
    float jumpTime;

    public GameObject chainSaw;
    Vector2 center;
    Vector2 offset;
    float angle;
    float radius;

    void Start()
    {
        jumpTime = .5f;
        center = chainSaw.transform.position;
    }
    void Update()
    {
        // The ball always looks at the center
        LookCenter();
        // If not jumping
        if (!isJumping.value)
        {
            FallOnGround();
        }
        else
        {
            Jump();
        }
        // If player touches to the screen, the ball will rotate whether its jumping or not
        if (Input.GetMouseButton(0))
        {
            RotatePlayer();
        }
        /////////////////   
    }
    void LookCenter()
    {
        Vector2 direction = (center - (Vector2)transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var offset = 90f;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
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
    void Jump()
    {
        // 1 second jump time always lessens until it reaches to 0
        jumpTime -= Time.deltaTime;
        transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
        if (jumpTime <= 0)
        {
            isJumping.value = false;
        }
        // Jump mechanic
    }
    // Gain score 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("White"))
        {
            gainScore?.Invoke();
            isJumping.value = true;
            jumpTime = .5f;

            if (colAS != null)
            {
                colAS.PlayOneShot(colAC);
            }
        }
    }
}
