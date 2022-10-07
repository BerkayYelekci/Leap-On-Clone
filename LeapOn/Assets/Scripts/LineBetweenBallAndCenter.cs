using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBetweenBallAndCenter : MonoBehaviour
{
    public Transform center;
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, center.position);   
    }
}
