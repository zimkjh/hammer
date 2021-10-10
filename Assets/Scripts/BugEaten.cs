using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEaten : MonoBehaviour
{
    public int bugType;
    void Start()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        if(bugType == 0)
        {
            rb.velocity = new Vector2(-2f, 1f);
        }
        else
        {
            rb.velocity = new Vector2(2f, 1f);
        }
        //Object.Destroy(gameObject, 0.2f);
        Object.Destroy(gameObject, 0.3f);
    }
}
