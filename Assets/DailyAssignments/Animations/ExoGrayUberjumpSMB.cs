using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExoGrayUberjumpSMB : StateMachineBehaviour {

    public float jumpSpeed;

    private float entryTime;
    private float startHeight;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateEnter(animator, stateInfo, layerIndex);

        entryTime = Time.time;
        startHeight = animator.transform.position.y;
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateIK(animator, stateInfo, layerIndex);

        if((Time.time - entryTime) / stateInfo.length < 50f)
        {
            animator.transform.position += Vector3.up *  jumpSpeed * Time.deltaTime;
        }
        else
        {
            animator.transform.position -= Vector3.up * jumpSpeed * Time.deltaTime;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateExit(animator, stateInfo, layerIndex);

        animator.transform.position = new Vector3(animator.transform.position.x, startHeight, animator.transform.position.z);
    }

}
