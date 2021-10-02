using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdOnExit : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("condition", 0);
    }
}
