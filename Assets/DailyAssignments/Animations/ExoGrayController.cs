using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExoGrayController : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;
    public Animator animator;
    public Transform objToGrab;
    public float tryGrabDist;

    public float speed;



    private void Update()
    {
        if(Input.GetAxis("Vertical") > 0)
        {
            speed += Time.deltaTime * acceleration * Input.GetAxis("Vertical");
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speed += Time.deltaTime * acceleration * Input.GetAxis("Vertical");
            if (speed < -maxSpeed)
            {
                speed = -maxSpeed;
            }
        }
        else
        {
            speed = 0;
        }

        transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;

        animator.SetFloat("Speed", speed);

        if(Input.GetAxis("Jump") > 0)
        {
            animator.SetTrigger("Jump");
        }
        else
        {
            animator.ResetTrigger("Jump");
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (Vector3.Distance(transform.position, objToGrab.position) <= tryGrabDist)
        {
            animator.SetLookAtWeight(1);
            animator.SetLookAtPosition(objToGrab.position);

            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKPosition(AvatarIKGoal.RightHand, objToGrab.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, objToGrab.rotation);

            //animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
            //animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
            //animator.SetIKPosition(AvatarIKGoal.RightFoot, objToGrab.position);
            //animator.SetIKRotation(AvatarIKGoal.RightFoot, objToGrab.rotation);

            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, objToGrab.position);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, objToGrab.rotation);
        }
        else
        {
            animator.SetLookAtWeight(0);

            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

            //animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
            //animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);

            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
        }
    }

}
