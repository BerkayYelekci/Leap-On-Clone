using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyScore : MonoBehaviour
{
    public static Action multiplyTheScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            multiplyTheScore?.Invoke();
        }
    }
}
