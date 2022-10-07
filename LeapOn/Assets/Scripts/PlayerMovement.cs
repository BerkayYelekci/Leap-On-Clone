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
    }
    // Rotates player clock-wise
    void RotatePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(centre, Vector3.back, rotateSpeed * Time.deltaTime);
            /*
            radius = Vector2.Distance(transform.position, chainSaw.transform.position);
            angle += rotateSpeed * Time.deltaTime;
            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
            transform.position = centre + offset;
            */
        }
    }
}
