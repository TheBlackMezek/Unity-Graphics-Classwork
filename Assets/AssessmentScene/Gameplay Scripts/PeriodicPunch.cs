using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicPunch : MonoBehaviour {

    public Animator sittingAnimator;

    private void Start()
    {
        InvokeRepeating("Punch", 0f, 10f);
    }

    private void Punch()
    {
        sittingAnimator.SetTrigger("Punch");
        Invoke("ResetTrigger", 0f);
    }

    private void ResetTrigger()
    {
        sittingAnimator.ResetTrigger("Punch");
    }

}
