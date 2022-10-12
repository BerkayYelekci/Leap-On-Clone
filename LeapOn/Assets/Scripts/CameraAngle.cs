using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAngle : MonoBehaviour
{
    public ScriptableBool isGameOver;
    public ScriptableInt distanceToCenter;
    public ScriptableVector3 midDistanceForCamera;
    float cameraAngleGameOver;
    public Camera mainCam;
    private void Update()
    {
        if (!isGameOver.value)
        {
            ArrangeCameraDistance();
            FocusOnTheMid();
        }
        else
        {
            cameraAngleGameOver = (midDistanceForCamera.value.magnitude * 3f) + 2;
            mainCam.DOOrthoSize(cameraAngleGameOver, 5f);
        }
    }
    void ArrangeCameraDistance()
    {
        mainCam.DOOrthoSize(midDistanceForCamera.value.magnitude * 3f, 5f);   
    }
    void FocusOnTheMid()
    {
        mainCam.transform.position = new Vector3(midDistanceForCamera.value.x, midDistanceForCamera.value.y, mainCam.transform.position.z);
    }
}
