using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    int type;
    public float disappearZone = -3.3f;
    public float flySpeed = 0.3f;
    private float direction;
    void Start()
    {
        direction = 0;
        type = Random.Range(0,2);
        if (type == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(19 / 255.0f, 1 / 255.0f, 255 / 255.0f, 255 / 255.0f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(254 / 255.0f, 3 / 255.0f, 0 / 255.0f, 255 / 255.0f);
        }
    }
    private void Update()
    {
        if (type >= 0)
        {
            if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject())
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began && touch.position.x < (Screen.width / 2))
                {
                    Touch(0);
                }
                else if(touch.phase == TouchPhase.Began && touch.position.x >= (Screen.width / 2))
                {
                    Touch(1);
                }
            }
            else if (!EventSystem.current.IsPointerOverGameObject())
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
        if(transform.position.y < disappearZone)
        {
            FindObjectOfType<SpawnerBlock>().newBlock();
            if(touchPosition == 0)
            {
                direction = -flySpeed;
            }
            else
            {
                direction = flySpeed;
            }
            if(touchPosition == type)
            {
                GameManager.I.addScore(1);
            }
            else
            {
                GameManager.I.GameOver();
            }
            type = -1;
            transform.position += new Vector3(0, 0, 1);
        }
        else
        {
            transform.position += new Vector3(0, -0.5f, 0);
        }
    }
}
