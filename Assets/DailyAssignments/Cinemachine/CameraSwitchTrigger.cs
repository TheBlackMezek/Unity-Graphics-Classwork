using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour {

    public bool permanentSwitch;
    public string playerTag;

    public Cinemachine.CinemachineVirtualCamera mainCam;
    public Cinemachine.CinemachineVirtualCamera triggerCam;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTag)
        {
            mainCam.enabled = false;
            triggerCam.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!permanentSwitch && other.tag == playerTag)
        {
            triggerCam.enabled = false;
            mainCam.enabled = true;
        }
    }

}
