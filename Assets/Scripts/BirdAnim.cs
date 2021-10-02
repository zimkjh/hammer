using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnim : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void birdEating()
    {
        Debug.Log("chane condition 1");
        animator.SetInteger("condition", 1);
    }
}
