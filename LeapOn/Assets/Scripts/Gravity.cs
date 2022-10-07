using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Transform gravityCenter;
    Vector2 targetDirection;


    public int forceAmount = 100;
    public float gravity;
    Rigidbody2D rb;

    void Start()
    {
        Physics2D.gravity = new Vector2(0, gravity);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FallOnTheGround();   
    }
    void FallOnTheGround()
    {
        targetDirection = gravityCenter.position - transform.position;
        targetDirection = targetDirection.normalized;
        rb.AddForce(targetDirection * forceAmount * Time.deltaTime);
    }
}
