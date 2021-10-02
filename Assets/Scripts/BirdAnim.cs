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
}
