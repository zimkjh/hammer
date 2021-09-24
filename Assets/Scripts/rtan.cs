using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    //readonly float baseDirection = 0.005f;
    readonly float baseToward = 1.0f;
    //float direction = 0.005f;
    float toward = 1.0f;

    void Update()
    {
        //if (transform.position.x > 2.8f)
        //{
        //    direction *= -1;
        //    toward *= -1;
        //}
        //else if (transform.position.x < -2.8f)
        //{
        //    direction *= -1;
        //    toward *= -1;
        //}
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x < (Screen.width / 2))
            {
                Touch(0);
            }
            else
            {
                Touch(1);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.x < (Screen.width / 2))
                {
                    Touch(0);
                }
                else
                {
                    Touch(1);
                }
            }
        }

        transform.localScale = new Vector3(toward, 1, 1);
        //transform.position += new Vector3(direction, 0.0f, 0.0f);
    }

    void Touch(int touchPosition)
    {
        if(touchPosition == 0)
        {
            toward = -baseToward;
        }
        else
        {
            toward = baseToward;
        }
    }
}
