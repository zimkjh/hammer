using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtan : MonoBehaviour
{
    float baseDirection = 0.005f;
    float baseToward = 1.0f;
    float direction = 0.005f;
    float toward = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 2.8f)
        {
            direction *= -1;
            toward *= -1;
        }
        else if (transform.position.x < -2.8f)
        {
            direction *= -1;
            toward *= -1;
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > (Screen.width / 2))
            {
                Debug.Log("right");
                direction = baseDirection;
                toward = baseToward;
            }
            else
            {
                Debug.Log("left");
                direction = -baseDirection;
                toward *= -baseToward;
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    direction *= -1;
        //    toward *= -1;
        //}

        transform.localScale = new Vector3(toward, 1, 1);
        transform.position += new Vector3(direction, 0.0f, 0.0f);
    }
}
