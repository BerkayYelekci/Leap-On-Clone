using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBetweenBallAndCenter : MonoBehaviour
{
    public Transform center;
    LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.sortingOrder = 14;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, center.position);   
    }
    private void Update()
    {
        lineRenderer.SetPosition(0, center.position);
        lineRenderer.SetPosition(1, transform.position);
    }
}
