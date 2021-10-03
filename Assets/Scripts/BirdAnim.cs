using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnim : MonoBehaviour
{
    public int type;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void birdEating()
    {
        animator.SetInteger("condition", 1);
    }
    private void Update()
    {
        if(GameManager.I.feverTime == true)
        {
            GameObject.Find("bird" + 0).GetComponent<Renderer>().enabled = false;
            GameObject.Find("bird" + 1).GetComponent<Renderer>().enabled = false;
            GameObject.Find("bird" + 100).GetComponent<Renderer>().enabled = true;
            GameObject.Find("bird" + 101).GetComponent<Renderer>().enabled = true;
        }
    }
}
