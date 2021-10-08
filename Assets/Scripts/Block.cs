using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    int type;
    public float disappearZone = -1.7f;
    public List<Sprite> bugImageList;
    public Sprite feverBugImage;
    public List<GameObject> bugEatenList;
    public List<GameObject> feverBugEatenList;
    private SpriteRenderer spriteRenderer; 
    void Start()
    {
        type = Random.Range(0,2);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bugImageList[type];
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
        if(GameManager.I.feverTime == true)
        {
            spriteRenderer.sprite = feverBugImage;
        }
        else
        {
            spriteRenderer.sprite = bugImageList[type];
        }
    }
    private void Touch(int touchPosition)
    {
        if(transform.position.y < disappearZone)
        {
            FindObjectOfType<SpawnerBlock>().newBlock();
            if(touchPosition == type || GameManager.I.feverTime)
            {
                GameManager.I.addScore(1);
            }
            else
            {
                GameManager.I.GameOver();
            }
            transform.position += new Vector3(0, 0, 1);
            GameObject.Find("bird" + touchPosition.ToString()).GetComponent<BirdAnim>().birdEating();
            if (GameManager.I.feverTime)
            {
                Instantiate(feverBugEatenList[touchPosition]);
            }
            else
            {
                Instantiate(bugEatenList[touchPosition]);
            }
            Destroy(gameObject);
        }
        else
        {
            transform.position += new Vector3(0, -0.4f, 0);
        }
    }
}
