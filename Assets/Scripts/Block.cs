using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int type;
    public float disappearZone = -2.6f;
    private float direction;
    void Start()
    {
        direction = 0;
        type = Random.Range(0,2);
        if (type == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(27 / 255.0f, 73 / 255.0f, 157 / 255.0f, 255 / 255.0f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(231 / 255.0f, 31 / 255.0f, 26 / 255.0f, 255 / 255.0f);
        }
    }
    private void Update()
    {
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
        if(transform.position.x < -4f || transform.position.x > 4f)
        {
            Destroy(gameObject);
        }
        transform.position += new Vector3(direction, 0, 0);
        //transform.localScale = new Vector3(0.9f, 1, 1);
    }
    void Touch(int touchPosition)
    {
        float flySpeed = 3f;
        if (touchPosition == 0)
        {
            Debug.Log("touched left");
            transform.position += new Vector3(0, -0.5f, 0);
            flySpeed *= -1;
        }
        else
        {
            Debug.Log("touched Right");
            transform.position += new Vector3(0, -0.5f, 0);
        }
        if(transform.position.y < disappearZone)
        {
            FindObjectOfType<SpawnerBlock>().newBlock();
            //transform.Translate(new Vector3(flySpeed, 0, 0));
            direction = 0.05f * flySpeed;
        }
        
    }
}
