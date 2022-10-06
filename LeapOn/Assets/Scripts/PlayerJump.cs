using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public ScriptableBool isJumping;

    GameObject player;
    Rigidbody2D playerRb;

    [SerializeField]
    float jumpForce;
    float time;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        time = 1f;
    }
    IEnumerator BouncePlayer()
    {
        isJumping.value = true;
        playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(time);
        isJumping.value = false;
        playerRb.velocity = new Vector2(0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(BouncePlayer());
        }
    }
}
