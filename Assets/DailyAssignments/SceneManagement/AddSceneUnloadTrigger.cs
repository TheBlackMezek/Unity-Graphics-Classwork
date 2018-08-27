using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSceneUnloadTrigger : MonoBehaviour {

    public string sceneName;



    private void OnTriggerEnter(Collider other)
    {
        AdditiveSceneLoader.Instance.UnloadScene(sceneName);
    }

}
