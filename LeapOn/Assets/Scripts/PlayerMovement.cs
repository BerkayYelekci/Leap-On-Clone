using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed = 5f;
    float radius;

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
