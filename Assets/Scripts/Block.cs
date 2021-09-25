using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject())
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
        else if(!EventSystem.current.IsPointerOverGameObject())
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
        float flySpeed = 0.15f;
        transform.position += new Vector3(0, -0.5f, 0);
        if (touchPosition == 0)
        {
            Debug.Log("touched left");
            flySpeed *= -1;
        }
        else
        {
            Debug.Log("touched Right");
        }
        if(transform.position.y < disappearZone)
        {
            FindObjectOfType<SpawnerBlock>().newBlock();
            direction = flySpeed;
            if(touchPosition == type)
            {
                Debug.Log("add score~");
                GameManager.I.addScore(1);
            }
            else
            {
                Debug.Log("Game over");
                GameManager.I.GameOver();
            }
        }
        
    }
}
