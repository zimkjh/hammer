using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    int type;
    public float disappearZone = -2.2f;
    public float flySpeed = 0.3f;
    public List<Sprite> bugImageList;
    public List<Sprite> birdEatingImageList;
    public List<Sprite> bugEatenImageList;
    private float direction;
    void Start()
    {
        direction = 0;
        type = Random.Range(0,2);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (type == 0)
        {
            spriteRenderer.sprite = bugImageList[0];
        }
        else
        {
            spriteRenderer.sprite = bugImageList[1];
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
            //birdAnimatorList[touchPosition].SetInteger("condition", 1);
            //GetComponent<Animator>().GetBehaviour<BirdAnim>().birdEating();
            Debug.Log("bird Eating animation~");
            FindObjectOfType<BirdAnim>().birdEating();
        }
        else
        {
            transform.position += new Vector3(0, -0.5f, 0);
        }
    }
}
