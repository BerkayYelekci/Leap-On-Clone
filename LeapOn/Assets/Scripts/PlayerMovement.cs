using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    AnimationCurve fallCurve;

    public static Action gainScore; 

    public ScriptableBool isJumping;

    CameraShake camShake;

    public Transform playerScale;

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
        camShake = GetComponent<CameraShake>();

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
        radius = Vector2.Distance(transform.position, chainSaw.transform.position);
        angle += rotateSpeed * Time.deltaTime;
        offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
    }
    void FallOnGround()
    {
        float speed = fallSpeed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, center, speed);
        transform.position = Vector3.Lerp(transform.position, center, fallCurve.Evaluate(speed));
    }
    void Jump()
    {
        // 1 second jump time always lessens until it reaches to 0
        jumpTime -= Time.deltaTime;
        transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
        if (jumpTime <= 0)
        {

        }
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
            gainScore?.Invoke();
            isJumping.value = true;
            jumpTime = .5f;
            EffectSequence();
        }
    }

    private void EffectSequence()
    {
        playerScale.DOScale(new Vector3(.1f, .60f), 0.1f).OnComplete(() =>
        {
            transform.DOScale(new Vector3(.30f, 0.30f), 0.15f);
        });


        camShake.ShakingSequence(); // may change where to call this function.

        if (colAS != null)
        {
            colAS.PlayOneShot(colAC);
        }
    }

}
