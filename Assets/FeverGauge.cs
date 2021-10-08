using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverGauge : MonoBehaviour
{
    private float leftX = -2.35f;
    private float rightX = 2.8f;
    private float centerY = 4.44f;
    private float scaleX = 5.132686f;
    private float scaleY = 0.1285504f;
    public float percent = 0;
    public void changePercent(float percentVal)
    {
        percent = percentVal;
    }
    public float getPercent()
    {
        return percent;
    }
    void Update()
    {
        transform.localScale = new Vector3(scaleX * percent / 100f, scaleY, 0);
        transform.position = new Vector3(leftX + (rightX - leftX) * percent / 200, centerY, 0);
    }
}
