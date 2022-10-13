using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float fallTime; // 1
    float realisticFallTime;
    Vector3 velocity = Vector3.zero;

    public static Action gainScore;
    public static Action onTouchWhite;

    public ScriptableBool isGameOver;
    public ScriptableBool isJumping;
    public ScriptableInt distanceToCenter;

    public Transform playerScale;

    public AudioSource colAS;
    public AudioClip colAC;

    public float rotateSpeed; 
    float fallSpeed;
    public float jumpSpeed;
    float jumpTime;
    float releaseTime;
    bool isRelease;

    public GameObject chainSaw;
    Vector2 center;
    Vector2 offset;
    float angle;
    float radius;

    void Start()
    {
        isRelease = false;
        releaseTime = .15f;
        realisticFallTime = .4f;
        jumpTime = .5f;
        center = chainSaw.transform.position;
    }
    void Update()
    {
        if (!isGameOver.value)
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
            if (Input.GetMouseButtonUp(0))
            {
                releaseTime = .15f;
                isRelease = true;
            }
            if (isRelease && releaseTime >= 0)
            {
                RotatePlayerOnMouseUp();
            }
            /////////////////
        }
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
        isRelease = false;
        radius = Vector2.Distance(transform.position, chainSaw.transform.position);
        angle += rotateSpeed * Time.deltaTime;
        offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
    }
    // Rotates player a little when player quits touching the screen
    void RotatePlayerOnMouseUp()
    {
        isRelease = true;
        radius = Vector2.Distance(transform.position, chainSaw.transform.position);
        angle += (rotateSpeed / 2) * Time.deltaTime;
        offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
        releaseTime -= Time.deltaTime;
    }
    void FallOnGround()
    {
        //float speed = fallSpeed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, center, speed);
        transform.position = Vector3.SmoothDamp(transform.position, center, ref velocity, fallTime);
        fallTime -= Time.deltaTime;
    }
    void Jump()
    {
        // These are for fall ground function
        fallTime = 1;
        velocity = Vector3.zero;
        /////////////////////////////////////
        
        transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
        jumpSpeed -= Time.deltaTime;
        //transform.position = Vector3.SmoothDamp(transform.position, Vector2.up, ref velocity, 5);

        // 1 second jump time always lessens until it reaches to 0
        jumpTime -= Time.deltaTime;
        // For more realistic start to falling
        if (jumpTime <= 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Vector2.up, ref velocity, realisticFallTime);
        }
        ///////////////////////////////////////
        if (jumpTime <= -.5f)
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
            onTouchWhite?.Invoke();
            gainScore?.Invoke();
            isJumping.value = true;
            jumpTime = .5f;
            jumpSpeed = 3f;
            // Hit sound plays
            if (colAS != null)
            {
                colAS.PlayOneShot(colAC);
            }
            // Bounce Effect
            playerScale.DOScale(new Vector3(.1f, .60f), 0.1f).OnComplete(() =>
            {
                transform.DOScale(new Vector3(.30f, 0.30f), 0.15f);
            });
        }
    }
}
