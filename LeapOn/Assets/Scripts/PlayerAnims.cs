using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    public GameObject leftEye, rightEye;
    public ScriptableBool isJumping;
    Vector2 velocity = Vector2.zero;
    Vector2 jumpEyesPosLeft, jumpEyesPosRight, leftEyeBasePos, rightEyeBasePos;
    void Start()
    {
        jumpEyesPosLeft = new Vector2(leftEye.transform.localPosition.x, .25f);
        jumpEyesPosRight = new Vector2(rightEye.transform.localPosition.x, .25f);
        leftEyeBasePos = new Vector2(.2f, -.3f);
        leftEyeBasePos = new Vector2(-.2f, -.3f);
    }
    void Update()
    {
        EyeMovement();
    }
    void EyeMovement()
    {
        if (isJumping.value)
        {
            leftEye.transform.localPosition = Vector2.SmoothDamp(leftEye.transform.localPosition, jumpEyesPosLeft, ref velocity, .3f);
            rightEye.transform.localPosition = Vector2.SmoothDamp(rightEye.transform.localPosition, jumpEyesPosRight, ref velocity, .3f);
        }
        else if (!isJumping.value)
        {
            leftEye.transform.localPosition = Vector2.SmoothDamp(leftEye.transform.localPosition, leftEyeBasePos, ref velocity, .3f);
            rightEye.transform.localPosition = Vector2.SmoothDamp(rightEye.transform.localPosition, rightEyeBasePos, ref velocity, .3f);
        }
    }
}
