using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public ScriptableBool isJumping;

    Vector2 targetDirection;
    GameObject player;
    Rigidbody2D playerRb;

    [SerializeField]
    float jumpForce;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    void JumpPlayer()
    {
        targetDirection = player.transform.position - transform.position;
        targetDirection = targetDirection.normalized;
        playerRb.AddForce(targetDirection * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JumpPlayer();
        }
    }
}
