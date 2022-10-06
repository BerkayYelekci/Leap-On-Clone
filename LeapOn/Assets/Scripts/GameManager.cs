using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScriptableBool isJumping;
    void Awake()
    {
        isJumping.value = false;
    }
}
