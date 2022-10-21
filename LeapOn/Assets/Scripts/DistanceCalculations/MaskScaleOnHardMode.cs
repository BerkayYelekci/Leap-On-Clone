using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MaskScaleOnHardMode : MonoBehaviour
{
    public GameObject maskScale;
    Vector2 defaultScaleValue, midScaleValue, maxScaleValue;
    public ScriptableInt distanceToCenter;
    float timeToScale;
    void Start()
    {
        timeToScale = 1f;
        maxScaleValue = new Vector2(10, 10);
        midScaleValue = new Vector2(8.5f, 8.5f);
        defaultScaleValue = new Vector2(7, 7);
        maskScale.gameObject.transform.localScale = defaultScaleValue;
    }
    private void Update()
    {
        ChangeScale();
    }
    void ChangeScale()
    {
        if (distanceToCenter.value <= 3)
        {
            maskScale.transform.DOScale(maxScaleValue, timeToScale);
        }
        else if (distanceToCenter.value > 3 && distanceToCenter.value < 6)
        {
            maskScale.transform.DOScale(midScaleValue, timeToScale);
        }
        else if (distanceToCenter.value >= 6)
        {
            maskScale.transform.DOScale(defaultScaleValue, timeToScale);
        }
    }
}
