using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCycler : MonoBehaviour
{

    public Cinemachine.CinemachineVirtualCamera[] cameras;

    private Cinemachine.CinemachineBrain brain;
    
    private int currentCam;



    private void OnValidate()
    {
        brain = GetComponent<Cinemachine.CinemachineBrain>();
    }

    private void Awake()
    {
        int topPriority = int.MinValue;
        for(int i = 0; i < cameras.Length; ++i)
        {
            if(cameras[i].m_Priority > topPriority)
            {
                currentCam = i;
                topPriority = cameras[i].m_Priority;
            }
        }
        for (int i = 0; i < cameras.Length; ++i)
        {
            if (i != currentCam)
            {
                cameras[i].enabled = false;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            cameras[currentCam].enabled = false;
            ++currentCam;
            if(currentCam >= cameras.Length)
            {
                currentCam = 0;
            }
            cameras[currentCam].enabled = true;
        }
    }

}
