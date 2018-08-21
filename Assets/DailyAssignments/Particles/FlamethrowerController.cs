using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerController : MonoBehaviour {

    private ParticleSystem ps;



    private void OnValidate()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ps.Play();
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            ps.Stop();
        }
    }

}
